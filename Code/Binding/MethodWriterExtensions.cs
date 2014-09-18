using System;
using Coding.Writers;

namespace Coding.Binding
{
    public static class MethodWriterExtensions
    {
        public static MethodWriter IsInternal(this MethodWriter method)
        {
            method.PrimaryAccessModifier = PrimaryAccessModifiers.Internal;
            return method;
        }

        public static MethodWriter IsPrivate(this MethodWriter method)
        {
            method.PrimaryAccessModifier = PrimaryAccessModifiers.Private;
            return method;
        }

        public static MethodWriter IsProtected(this MethodWriter method)
        {
            method.PrimaryAccessModifier = PrimaryAccessModifiers.Protected;
            return method;
        }

        public static MethodWriter IsPublic(this MethodWriter method)
        {
            method.PrimaryAccessModifier = PrimaryAccessModifiers.Public;
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

        public static MethodWriter IsExtensionMethod(this MethodWriter method, ParameterWriter parameter)
        {
            method.ExtensionParameter = parameter;
            return method.IsStatic();
        }

        public static MethodWriter IsExtensionMethod(this MethodWriter method, TypeWriter type, string name, Action<ParameterWriter> configAction = null)
        {
            var parameter = new ParameterWriter(type, name);

            if (configAction != null)
            {
                configAction.Invoke(parameter);
            }

            return method.IsExtensionMethod(parameter);
        }

        public static MethodWriter IsExtensionMethod<TParamType>(this MethodWriter method, string name, Action<ParameterWriter> configAction = null) 
        {
            return method.IsExtensionMethod(To.VariableTypeWriter<TParamType>(), name, configAction);
        }

        public static MethodWriter HasGenericParameter(this MethodWriter method, GenericParameterWriter genericParameterWriter)
        {
            method.GenericParameters.Add(genericParameterWriter);
            return method;
        }

        public static MethodWriter HasGenericParameter(this MethodWriter method, string name, Action<GenericParameterWriter> configAction = null)
        {
            var genericParameter = new GenericParameterWriter(name);

            if (configAction != null)
            {
                configAction.Invoke(genericParameter);
            }

            return method.HasGenericParameter(genericParameter);
        }

        public static MethodWriter HasParameter(this MethodWriter method, ParameterWriter parameter)
        {
            method.Parameters.Add(parameter);
            return method;
        }

        public static MethodWriter HasParameter(this MethodWriter method, TypeWriter type, string name)
        {
            return method.HasParameter(new ParameterWriter(type, name));
        }

        public static MethodWriter HasParameter<TParamType>(this MethodWriter method, string name)
        {
            return method.HasParameter(To.VariableTypeWriter<TParamType>(), name);
        }

        public static MethodWriter HasParamsParameter(this MethodWriter method, ParamsParameterWriter paramsParameter)
        {
            if (method.ParamsParameter != null)
            {
                throw new InvalidOperationException("Params parameter is already set.");
            }
            
            method.ParamsParameter = paramsParameter;
            return method;
        }

        public static MethodWriter HasParamsParameter(this MethodWriter method, TypeWriter type, string name)
        {
            return method.HasParamsParameter(new ParamsParameterWriter(type, name));
        }

        public static MethodWriter HasParamsParameter<TParamType>(this MethodWriter method, string name)
        {
            return method.HasParamsParameter(To.VariableTypeWriter<TParamType>(), name);
        }

        public static MethodWriter HasReturnType(this MethodWriter method, TypeWriter parameter)
        {
            if (method.ReturnType != null)
            {
                throw new ArgumentException("Method return type is already set.");
            }

            method.ReturnType = parameter;
            return method;
        }

        public static MethodWriter HasReturnType<TReturnType>(this MethodWriter method)
        {
            return method.HasReturnType(To.VariableTypeWriter<TReturnType>());
        }
    }
}