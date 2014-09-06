using System;
using System.Linq;
using Coding;

using CSharp.Writers;

namespace CSharp.Binding
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

        public static ClassWriter IsGeneric(this ClassWriter @class, GenericDeclarationWriter genericDeclaration)
        {
            @class.GenericDeclaration = genericDeclaration;
            return @class;
        }

        public static ClassWriter IsGeneric(this ClassWriter @class, params GenericParameterWriter[] genericParameterWriters)
        {
            return @class.IsGeneric(new GenericDeclarationWriter(genericParameterWriters.ToList()));
        }

        public static ClassWriter IsGeneric(this ClassWriter @class, Action<GenericDeclarationWriter> configAction)
        {
            var genericDeclaration = new GenericDeclarationWriter();
            configAction.Invoke(genericDeclaration);
            return @class.IsGeneric(genericDeclaration);
        }

        public static ClassWriter Has(this ClassWriter @class, IClassChild child)
        {
            @class.Children.Add(child);
            return @class;
        }

        public static ClassWriter HasProperty<TParamType>(this ClassWriter @class, string name, Action<PropertyWriter> configAction = null)
        {
            return @class.HasProperty(new TypeParameterWriter<TParamType>(), name, configAction);
        }
        
        public static ClassWriter HasProperty(this ClassWriter @class, IParameterTypeWriter type, string name, Action<PropertyWriter> configAction = null)
        {
            var property = new PropertyWriter(type, name);

            if (configAction != null)
            {
                configAction.Invoke(property);
            }
            
            return @class.Has(property);
        }

        public static ClassWriter HasField<TParamType>(this ClassWriter @class, string name, Action<FieldWriter> configAction = null)
        {
            return @class.HasField(new TypeParameterWriter<TParamType>(), name, configAction);
        }

        public static ClassWriter HasField(this ClassWriter @class, IParameterTypeWriter type, string name, Action<FieldWriter> configAction = null)
        {
            var field = new FieldWriter(type, name);

            if (configAction != null)
            {
                configAction.Invoke(field);
            }

            return @class.Has(field);
        }

        public static ClassWriter HasMethod<TReturnType>(this ClassWriter @class, string name, Action<MethodWriter> configAction = null)
        {
            var method = new MethodWriter(name).HasReturnType<TReturnType>();
            
            if (configAction != null)
            {
                configAction.Invoke(method);
            }

            return @class.Has(method);
        }

        public static ClassWriter HasMethod(this ClassWriter @class, string name, Action<MethodWriter> configAction = null)
        {
            var method = new MethodWriter(name);

            if (configAction != null)
            {
                configAction.Invoke(method);
            }

            return @class.Has(method);
        }
    }
}