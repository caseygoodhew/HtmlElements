using Coding;

using CSharp.Writers;

namespace CSharp.Binding
{
    public static class GenericParameterWriterExtensions
    {
        public static GenericParameterWriter WhereIsNew(this GenericParameterWriter genericParameter)
        {
            genericParameter.Constraints.Add(new GenericParameterConstraintOfTokenWriter(Token.GenericNew));
            return genericParameter;
        }

        public static GenericParameterWriter WhereIsClass(this GenericParameterWriter genericParameter)
        {
            genericParameter.Constraints.Add(new GenericParameterConstraintOfTokenWriter(Token.Class));
            return genericParameter;
        }

        public static GenericParameterWriter WhereIsStruct(this GenericParameterWriter genericParameter)
        {
            genericParameter.Constraints.Add(new GenericParameterConstraintOfTokenWriter(Token.Struct));
            return genericParameter;
        }

        public static GenericParameterWriter WhereIsType(this GenericParameterWriter genericParameter, IParameterTypeWriter parameterType) 
        {
            genericParameter.Constraints.Add(new GenericParameterConstraintOfTypeWriter(parameterType));
            return genericParameter;
        }
    }
}