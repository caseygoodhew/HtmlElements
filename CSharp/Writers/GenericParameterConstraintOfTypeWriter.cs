using Coding;

namespace CSharp.Writers
{
    public class GenericParameterConstraintOfTypeWriter : Writer, IGenericParameterConstraint
    {
        private readonly IParameterTypeWriter parameterType;
        
        public GenericParameterConstraintOfTypeWriter(IParameterTypeWriter parameterType)
        {
            this.parameterType = parameterType;
        }

        public override void Build(TokenBuilder builder)
        {
            builder.Add(parameterType.BuildParameterTypeName);
        }
    }
}