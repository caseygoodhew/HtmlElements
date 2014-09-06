using System;
using System.Linq;
using Coding;
using CSharp.Writers;

namespace CSharp.Binding
{
    public static class MethodWriterExtensions
    {
        public static MethodWriter IsInternal(this MethodWriter method)
        {
            method.AccessModifier = PrimaryAccessModifiers.Internal;
            return method;
        }

        public static MethodWriter IsPrivate(this MethodWriter method)
        {
            method.AccessModifier = PrimaryAccessModifiers.Private;
            return method;
        }

        public static MethodWriter IsProtected(this MethodWriter method)
        {
            method.AccessModifier = PrimaryAccessModifiers.Protected;
            return method;
        }

        public static MethodWriter IsPublic(this MethodWriter method)
        {
            method.AccessModifier = PrimaryAccessModifiers.Public;
            return method;
        }

        public static MethodWriter IsAbstract(this MethodWriter method)
        {
            if (method.ExtensionParameter != null)
            {
                throw new InvalidOperationException("Extension methods cannot be abstract.");
            }

            method.SecondaryAccessModifier = SecondaryAccessModifiers.Abstract;
            return method;
        }

        public static MethodWriter IsVirtual(this MethodWriter method)
        {
            if (method.ExtensionParameter != null)
            {
                throw new InvalidOperationException("Extension methods cannot be virtual.");
            }

            method.SecondaryAccessModifier = SecondaryAccessModifiers.Virtual;
            return method;
        }

        public static MethodWriter IsOverride(this MethodWriter method)
        {
            if (method.ExtensionParameter != null)
            {
                throw new InvalidOperationException("Extension methods cannot be overrides.");
            }
            
            method.SecondaryAccessModifier = SecondaryAccessModifiers.Override;
            return method;
        }

        public static MethodWriter IsStatic(this MethodWriter method)
        {
            method.SecondaryAccessModifier = SecondaryAccessModifiers.Static;
            return method;
        }

        public static MethodWriter IsExtensionMethod(this MethodWriter method, ExtensionParameterWriter parameter)
        {
            method.ExtensionParameter = parameter;
            return method.IsStatic();
        }

        public static MethodWriter IsExtensionMethod(this MethodWriter method, IParameterTypeWriter type, string name, Action<ParameterWriter> configAction = null)
        {
            var parameter = new ExtensionParameterWriter(type, name);

            if (configAction != null)
            {
                configAction.Invoke(parameter);
            }

            return method.IsExtensionMethod(parameter);
        }

        public static MethodWriter IsExtensionMethod<TParamType>(this MethodWriter method, string name, Action<ParameterWriter> configAction = null)
        {
            return method.IsExtensionMethod(new TypeParameterWriter<TParamType>(), name, configAction);
        }

        public static MethodWriter IsGeneric(this MethodWriter method, GenericDeclarationWriter genericDeclaration)
        {
            method.GenericDeclaration = genericDeclaration;
            return method;
        }

        public static MethodWriter IsGeneric(this MethodWriter method, params GenericParameterWriter[] genericParameterWriters)
        {
            return method.IsGeneric(new GenericDeclarationWriter(genericParameterWriters.ToList()));
        }

        public static MethodWriter IsGeneric(this MethodWriter method, Action<GenericDeclarationWriter> configAction)
        {
            var genericDeclaration = new GenericDeclarationWriter();
            configAction.Invoke(genericDeclaration);
            return method.IsGeneric(genericDeclaration);
        }
            
        public static MethodWriter HasParameter(this MethodWriter method, ParameterWriter parameter)
        {
            if (parameter is ExtensionParameterWriter)
            {
                throw new ArgumentException("Extension parameters must be created through IsExtensionMethod.");
            }

            method.Parameters.Add(parameter);
            return method;
        }

        public static MethodWriter HasParameter(this MethodWriter method, IParameterTypeWriter type, string name, Action<ParameterWriter> configAction = null)
        {
            var parameter = new ParameterWriter(type, name);

            if (configAction != null)
            {
                configAction.Invoke(parameter);
            }

            return method.HasParameter(parameter);
        }

        public static MethodWriter HasParameter<TParamType>(this MethodWriter method, string name, Action<ParameterWriter> configAction = null)
        {
            return method.HasParameter(new TypeParameterWriter<TParamType>(), name, configAction);
        }

        public static MethodWriter HasReturnType(this MethodWriter method, IParameterTypeWriter parameter)
        {
            if (method.ReturnType != null)
            {
                throw new ArgumentException("Method return type is already set.");
            }

            method.ReturnType = parameter;
            return method;
        }

        public static MethodWriter HasReturnType<TParamType>(this MethodWriter method, Action<IParameterTypeWriter> configAction = null)
        {
            var parameterType = new TypeParameterWriter<TParamType>();

            if (configAction != null)
            {
                configAction.Invoke(parameterType);
            }

            return method.HasReturnType(parameterType);
        }
    }
}