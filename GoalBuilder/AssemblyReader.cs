using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Definition;
using Definition.Attributes;
using Definition.Elements;
using Definition.Validation;

namespace GoalBuilder
{
    public class AssemblyReader
    {
        public void Read(Type assemblyType)
        {
            var assembly = Assembly.GetAssembly(assemblyType);
            /*var types = assembly.GetTypes().ToList();

            var elementType = assembly.GetType("Definition.Elements.Element");
            var elements = types.Where(elementType.IsAssignableFrom).ToList();

            var attributeType = assembly.GetType("Definition.Attributes.AttributeDefinition");
            var attributes = types.Where(attributeType.IsAssignableFrom).ToList();*/

            var elements = ElementReader.Read(assembly);
            var attributes = AttributeReader.Read(assembly);

            ElementAttributeBinder.Bind(elements, attributes);

            int y = 0;
        }
    }

    internal static class ElementAttributeBinder
    {
        public static void Bind(IEnumerable<ElementInfo> elements, IEnumerable<AttributeInfo> attributes)
        {
            var elementList = elements.ToList();

            var elementMapping = elementList.ToDictionary(x => x.DefinitionType);

            var bindMapping =
                attributes.SelectMany(
                    x =>
                        x.DefinitionType.GetCustomAttributes<AppliesToElementAttribute>()
                            .Select(a => new ElementAttributeReference
                            {
                                AttributeInfo = x,
                                ElementInfo = elementMapping[a.ElementType],
                                ReferenceUrl = a.Url
                            }));

            bindMapping.GroupBy(x => x.ElementInfo).ToList().ForEach(x =>
            {
                x.Key.AttributeReferences = x.ToList();
            });
        }
    }

    internal static class AttributeReader
    {
        public static IEnumerable<AttributeInfo> Read(Assembly assembly)
        {
            var types = assembly.GetTypes().ToList();

            var attributeDefinitionType = assembly.GetType("Definition.Attributes.AttributeDefinition");

            return types.Where(attributeDefinitionType.IsAssignableFrom).Select(CreateAttributeFromType);            
        }

        private static AttributeInfo CreateAttributeFromType(Type type)
        {
            var attribute = new AttributeInfo
            {
                IsAbstract = type.IsAbstract,
                DefinitionType = type
            };

            if (!type.IsAbstract)
            {
                var instance = (AttributeDefinition)Activator.CreateInstance(type);

                attribute.Name = instance.Name;
                attribute.AttributeValueType = instance.AttributeValueType;
                attribute.ValidatorInfo = new ValidatorInfo(type.GetCustomAttribute<ValidatorAttribute>());
            }

            return attribute;
        }
    }

    internal static class ElementReader
    {
        public static IEnumerable<ElementInfo> Read(Assembly assembly)
        {
            var types = assembly.GetTypes().ToList();

            var elementDefinitionType = assembly.GetType("Definition.Elements.ElementDefinition");
            var elementDefinitionTypes = types.Where(elementDefinitionType.IsAssignableFrom);

            var elements = elementDefinitionTypes.Select(CreateElementFromType).ToList();

            var mapping = elements.ToDictionary(x => x.DefinitionType);

            elements.ForEach(x =>
            {
                x.InheritedFrom = GetInheritedFrom(mapping, x.DefinitionType);
                x.RestrictChildrenTo = GetRestrictChildrenTo(mapping, x.DefinitionType);
                x.RestrictToParentsOf = GetRestrictToParentsOf(mapping, x.DefinitionType);
            });

            return elements;
        }

        private static ElementInfo CreateElementFromType(Type type)
        {
            var element = new ElementInfo
            {
                IsAbstract = type.IsAbstract,
                Reference = ReadReferenceAttribute(type),
                ElementTypes = ReadElementTypeAttribute(type),
                DefinitionType = type
            };

            if (!type.IsAbstract)
            {
                var instance = (ElementDefinition)Activator.CreateInstance(type);
                
                element.Tag = instance.Tag;
                element.Structure = instance.Structure;
            }

            return element;
        }

        private static string ReadReferenceAttribute(MemberInfo memberInfo)
        {
            var reference = memberInfo.GetCustomAttribute<ReferenceAttribute>();

            return reference == null ? string.Empty : reference.Url;
        }

        private static IEnumerable<ElementType> ReadElementTypeAttribute(MemberInfo memberInfo)
        {
            var elementTypes = memberInfo.GetCustomAttributes<ElementTypeAttribute>(true);
            
            return elementTypes.SelectMany(x => x.ElementTypes);
        }

        private static ElementInfo GetInheritedFrom(IDictionary<Type, ElementInfo> lookup, Type type)
        {
            return type == typeof(ElementDefinition) ? null : lookup[type.BaseType];
        }

        private static IEnumerable<ElementInfo> GetRestrictChildrenTo(IDictionary<Type, ElementInfo> lookup, Type type)
        {
            var restrictTo = type.GetCustomAttributes<RestrictChildrenToAttribute>(true);

            return restrictTo.Select(x => lookup[x.ChildType]);
        }

        private static IEnumerable<ElementInfo> GetRestrictToParentsOf(IDictionary<Type, ElementInfo> lookup, Type type)
        {
            var restrictTo = type.GetCustomAttributes<RestrictToParentOfAttribute>(true);

            return restrictTo.Select(x => lookup[x.ParentType]);
        }
    }
}
