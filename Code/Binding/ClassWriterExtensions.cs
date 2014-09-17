using System;
using Coding.Writers;

namespace Coding.Binding
{
    public static class ClassWriterExtensions
    {
        /*********************************************************
         *  Primary Access Modifier
         ********************************************************/
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

        /*********************************************************
         *  Secondary Access Modifier
         ********************************************************/
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

        /*********************************************************
         *  Generic Parameters
         ********************************************************/
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

        /*********************************************************
         *  Utility
         ********************************************************/
        public static ClassWriter Has(this ClassWriter @class, FieldWriter field)
        {
            return @class.HasField(field);
        }

        public static ClassWriter Has(this ClassWriter @class, PropertyWriter property)
        {
            return @class.HasProperty(property);
        }

        public static ClassWriter Has(this ClassWriter @class, ConstructorWriter constructor)
        {
            return @class.HasConstructor(constructor);
        }

        public static ClassWriter Has(this ClassWriter @class, MethodWriter method)
        {
            return @class.HasMethod(method);
        }

        /*********************************************************
         *  Properties
         ********************************************************/
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

        /*********************************************************
         *  Fields
         ********************************************************/
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

        /*********************************************************
         *  Constructors
         ********************************************************/
        public static ClassWriter HasConstructor(this ClassWriter @class, ConstructorWriter constructor)
        {
            @class.Constructors.Add(constructor);
            return @class;
        }

        public static ClassWriter HasConstructor(this ClassWriter @class, string name, Action<ConstructorWriter> configAction = null)
        {
            var constructor = new ConstructorWriter(@class);

            if (configAction != null)
            {
                configAction.Invoke(constructor);
            }

            return @class.HasConstructor(constructor);
        }

        /*********************************************************
         *  Methods
         ********************************************************/
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

        /*********************************************************
         *  Extends Class
         ********************************************************/
        public static ClassWriter Extends(this ClassWriter @class, ClassWriter extendsClass)
        {
            return @class.Extends(new ExtendsClassTypeWriter(extendsClass));
        }

        public static ClassWriter Extends<T>(this ClassWriter @class) where T : class
        {
            return @class.Extends(new ExtendsGenericClassWriter<T>());
        }

        public static ClassWriter Extends(this ClassWriter @class, ExtendsClassWriter extendsClass)
        {
            if (@class.ExtendsClass != null)
            {
                throw new InvalidOperationException("Extension class already exists.");
            }

            @class.ExtendsClass = extendsClass;
            return @class;
        }

        /*********************************************************
         *  Implmements Interfaces
         ********************************************************/
        public static ClassWriter Implments(this ClassWriter @class, InterfaceWriter implementsInterface)
        {
            return @class.Implments(new ImplementsInterfaceTypeWriter(implementsInterface));
        }

        public static ClassWriter Implments<T>(this ClassWriter @class) where T : class
        {
            return @class.Implments(new ImplementsGenericInterfaceWriter<T>());
        }

        public static ClassWriter Implments(this ClassWriter @class, ImplementsInterfaceWriter implementsInterface)
        {
            @class.ImplementsInterfaceWriters.Add(implementsInterface);
            return @class;
        }
    }
}