using System;
using System.Linq;
using Coding.Writers;


namespace Coding.Binding
{
    public static class ClassWriterExtensions
    {
        public static ClassWriter IsPublic(this ClassWriter @class)
        {
            @class.PrimaryAccessModifier = PrimaryAccessModifiers.Public;
            return @class;
        }

        public static ClassWriter IsPrivate(this ClassWriter @class)
        {
            @class.PrimaryAccessModifier = PrimaryAccessModifiers.Private;
            return @class;
        }

        public static ClassWriter IsProtected(this ClassWriter @class)
        {
            @class.PrimaryAccessModifier = PrimaryAccessModifiers.Protected;
            return @class;
        }

        public static ClassWriter IsInternal(this ClassWriter @class)
        {
            @class.PrimaryAccessModifier = PrimaryAccessModifiers.Internal;
            return @class;
        }

        public static ClassWriter IsAbstract(this ClassWriter @class)
        {
            if (@class.SecondaryAccessModifier.HasValue)
            {
                throw new InvalidOperationException();
            }

            @class.SecondaryAccessModifier = SecondaryAccessModifiers.Abstract;
            return @class;
        }

        public static ClassWriter IsStatic(this ClassWriter @class)
        {
            if (@class.SecondaryAccessModifier.HasValue)
            {
                throw new InvalidOperationException();
            }

            @class.SecondaryAccessModifier = SecondaryAccessModifiers.Static;
            return @class;
        }

        public static ClassWriter IsReadonly(this ClassWriter @class)
        {
            if (@class.SecondaryAccessModifier.HasValue)
            {
                throw new InvalidOperationException();
            }

            @class.SecondaryAccessModifier = SecondaryAccessModifiers.Readonly;
            return @class;
        }

        public static ClassWriter IsStaticReadonly(this ClassWriter @class)
        {
            if (@class.SecondaryAccessModifier.HasValue)
            {
                throw new InvalidOperationException();
            }

            @class.SecondaryAccessModifier = SecondaryAccessModifiers.StaticReadonly;
            return @class;
        }

        public static ClassWriter HasGenericParameter(this ClassWriter @class, GenericParameterWriter genericParameterWriter)
        {
            @class.GenericParameters.Add(genericParameterWriter);
            return @class;
        }

        public static ClassWriter HasGenericParameter(this ClassWriter @class, string name, Action<GenericParameterWriter> configAction = null)
        {
            var genericParameter = new GenericParameterWriter(name);

            if (configAction != null)
            {
                configAction.Invoke(genericParameter);
            }

            return @class.HasGenericParameter(genericParameter);
        }

        public static ClassWriter Has(this ClassWriter @class, FieldWriter field)
        {
            return @class.HasField(field);
        }

        public static ClassWriter Has(this ClassWriter @class, PropertyWriter property)
        {
            return @class.HasProperty(property);
        }

        public static ClassWriter Has(this ClassWriter @class, MethodWriter method)
        {
            return @class.HasMethod(method);
        }

        public static ClassWriter HasProperty<TParamType>(this ClassWriter @class, string name, Action<PropertyWriter> configAction = null)
        {
            return @class.HasProperty(To.VariableTypeWriter<TParamType>(), name, configAction);
        }

        public static ClassWriter HasProperty(this ClassWriter @class, PropertyWriter property)
        {
            @class.Properties.Add(property);
            return @class;
        }

        public static ClassWriter HasProperty(this ClassWriter @class, VariableTypeWriter type, string name, Action<PropertyWriter> configAction = null)
        {
            var property = new PropertyWriter(type, name);

            if (configAction != null)
            {
                configAction.Invoke(property);
            }

            return @class.HasProperty(property);
        }

        public static ClassWriter HasField<TParamType>(this ClassWriter @class, string name, Action<FieldWriter> configAction = null)
        {
            return @class.HasField(To.VariableTypeWriter<TParamType>(), name, configAction);
        }

        public static ClassWriter HasField(this ClassWriter @class, FieldWriter field)
        {
            @class.Fields.Add(field);
            return @class;
        }

        public static ClassWriter HasField(this ClassWriter @class, VariableTypeWriter type, string name, Action<FieldWriter> configAction = null)
        {
            var field = new FieldWriter(type, name);

            if (configAction != null)
            {
                configAction.Invoke(field);
            }

            return @class.HasField(field);
        }

        public static ClassWriter HasMethod<TReturnType>(this ClassWriter @class, string name, Action<MethodWriter> configAction = null)
        {
            var method = new MethodWriter(name).HasReturnType(To.VariableTypeWriter<TReturnType>());
            
            if (configAction != null)
            {
                configAction.Invoke(method);
            }

            @class.Methods.Add(method);
            return @class;
        }

        public static ClassWriter HasMethod(this ClassWriter @class, MethodWriter method)
        {
            @class.Methods.Add(method);
            return @class;
        }

        public static ClassWriter HasMethod(this ClassWriter @class, string name, Action<MethodWriter> configAction = null)
        {
            var method = new MethodWriter(name);

            if (configAction != null)
            {
                configAction.Invoke(method);
            }

            return @class.HasMethod(method);
        }
    }
}