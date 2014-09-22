using System;
using Coding.Writers;

namespace Coding.Binding
{
    public static class ConstructorWriterExtensions
    {
        public static ConstructorWriter IsInternal(this ConstructorWriter constructor)
        {
            constructor.PrimaryAccessModifier = PrimaryAccessModifiers.Internal;
            return constructor;
        }

        public static ConstructorWriter IsPrivate(this ConstructorWriter constructor)
        {
            constructor.PrimaryAccessModifier = PrimaryAccessModifiers.Private;
            return constructor;
        }

        public static ConstructorWriter IsProtected(this ConstructorWriter constructor)
        {
            constructor.PrimaryAccessModifier = PrimaryAccessModifiers.Protected;
            return constructor;
        }

        public static ConstructorWriter IsPublic(this ConstructorWriter constructor)
        {
            constructor.PrimaryAccessModifier = PrimaryAccessModifiers.Public;
            return constructor;
        }

        public static ConstructorWriter HasParameter(this ConstructorWriter constructor, ParameterWriter parameter)
        {
            constructor.Parameters.Add(parameter);
            return constructor;
        }

        public static ConstructorWriter HasParameter(this ConstructorWriter constructor, TypeWriter type, string name)
        {
            return constructor.HasParameter(new ParameterWriter(type, name));
        }

        public static ConstructorWriter HasParameter<TParamType>(this ConstructorWriter constructor, string name)
        {
            return constructor.HasParameter(To.GetTypeWriter<TParamType>(), name);
        }

        public static ConstructorWriter HasParamsParameter(this ConstructorWriter constructor, ParamsParameterWriter paramsParameter)
        {
            if (constructor.ParamsParameter != null)
            {
                throw new InvalidOperationException("Params parameter is already set.");
            }
            
            constructor.ParamsParameter = paramsParameter;
            return constructor;
        }

        public static ConstructorWriter HasParamsParameter(this ConstructorWriter constructor, TypeWriter type, string name)
        {
            return constructor.HasParamsParameter(new ParamsParameterWriter(type, name));
        }

        public static ConstructorWriter HasParamsParameter<TParamType>(this ConstructorWriter constructor, string name)
        {
            return constructor.HasParamsParameter(To.GetTypeWriter<TParamType>(), name);
        }
    }
}