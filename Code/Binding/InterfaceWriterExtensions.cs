using System;
using Coding.Writers;

namespace Coding.Binding
{
    public static class InterfaceWriterExtensions
    {
        /*********************************************************
         *  Primary Access Modifier
         ********************************************************/
        public static InterfaceWriter IsPublic(this InterfaceWriter @interface)
        {
            @interface.PrimaryAccessModifier = PrimaryAccessModifiers.Public;
            return @interface;
        }

        public static InterfaceWriter IsPrivate(this InterfaceWriter @interface)
        {
            @interface.PrimaryAccessModifier = PrimaryAccessModifiers.Private;
            return @interface;
        }

        public static InterfaceWriter IsProtected(this InterfaceWriter @interface)
        {
            @interface.PrimaryAccessModifier = PrimaryAccessModifiers.Protected;
            return @interface;
        }

        public static InterfaceWriter IsInternal(this InterfaceWriter @interface)
        {
            @interface.PrimaryAccessModifier = PrimaryAccessModifiers.Internal;
            return @interface;
        }

        /*********************************************************
         *  Generic Parameters
         ********************************************************/
        public static InterfaceWriter HasGenericParameter(this InterfaceWriter @interface, GenericParameterWriter genericParameterWriter)
        {
            @interface.GenericParameters.Add(genericParameterWriter);
            return @interface;
        }

        public static InterfaceWriter HasGenericParameter(this InterfaceWriter @interface, string name, Action<GenericParameterWriter> configAction = null)
        {
            var genericParameter = new GenericParameterWriter(name);

            if (configAction != null)
            {
                configAction.Invoke(genericParameter);
            }

            return @interface.HasGenericParameter(genericParameter);
        }

        /*********************************************************
         *  Utility
         ********************************************************/
        public static InterfaceWriter Has(this InterfaceWriter @interface, FieldWriter field)
        {
            return @interface.HasField(field);
        }

        public static InterfaceWriter Has(this InterfaceWriter @interface, PropertyWriter property)
        {
            return @interface.HasProperty(property);
        }

        public static InterfaceWriter Has(this InterfaceWriter @interface, MethodWriter method)
        {
            return @interface.HasMethod(method);
        }

        /*********************************************************
         *  Properties
         ********************************************************/
        public static InterfaceWriter HasProperty<TParamType>(this InterfaceWriter @interface, string name, Action<PropertyWriter> configAction = null)
        {
            return @interface.HasProperty(To.VariableTypeWriter<TParamType>(), name, configAction);
        }

        public static InterfaceWriter HasProperty(this InterfaceWriter @interface, PropertyWriter property)
        {
            @interface.Properties.Add(property);
            return @interface;
        }

        public static InterfaceWriter HasProperty(this InterfaceWriter @interface, VariableTypeWriter type, string name, Action<PropertyWriter> configAction = null)
        {
            var property = new PropertyWriter(type, name);

            if (configAction != null)
            {
                configAction.Invoke(property);
            }

            return @interface.HasProperty(property);
        }

        /*********************************************************
         *  Fields
         ********************************************************/
        public static InterfaceWriter HasField<TParamType>(this InterfaceWriter @interface, string name, Action<FieldWriter> configAction = null)
        {
            return @interface.HasField(To.VariableTypeWriter<TParamType>(), name, configAction);
        }

        public static InterfaceWriter HasField(this InterfaceWriter @interface, FieldWriter field)
        {
            @interface.Fields.Add(field);
            return @interface;
        }

        public static InterfaceWriter HasField(this InterfaceWriter @interface, VariableTypeWriter type, string name, Action<FieldWriter> configAction = null)
        {
            var field = new FieldWriter(type, name);

            if (configAction != null)
            {
                configAction.Invoke(field);
            }

            return @interface.HasField(field);
        }

        /*********************************************************
         *  Methods
         ********************************************************/
        public static InterfaceWriter HasMethod<TReturnType>(this InterfaceWriter @interface, string name, Action<MethodWriter> configAction = null)
        {
            var method = new MethodWriter(name).HasReturnType(To.VariableTypeWriter<TReturnType>());

            if (configAction != null)
            {
                configAction.Invoke(method);
            }

            @interface.Methods.Add(method);
            return @interface;
        }

        public static InterfaceWriter HasMethod(this InterfaceWriter @interface, MethodWriter method)
        {
            @interface.Methods.Add(method);
            return @interface;
        }

        public static InterfaceWriter HasMethod(this InterfaceWriter @interface, string name, Action<MethodWriter> configAction = null)
        {
            var method = new MethodWriter(name);

            if (configAction != null)
            {
                configAction.Invoke(method);
            }

            return @interface.HasMethod(method);
        }

        /*********************************************************
         *  Implmements Interfaces
         ********************************************************/
        public static InterfaceWriter Implments(this InterfaceWriter @interface, InterfaceWriter implementsInterface)
        {
            return @interface.Implments(new ImplementsInterfaceTypeWriter(implementsInterface));
        }

        public static InterfaceWriter Implments<T>(this InterfaceWriter @interface) where T : class
        {
            return @interface.Implments(new ImplementsGenericInterfaceWriter<T>());
        }

        public static InterfaceWriter Implments(this InterfaceWriter @interface, ImplementsInterfaceWriter implementsInterface)
        {
            @interface.ImplementsInterfaceWriters.Add(implementsInterface);
            return @interface;
        }
    }
}