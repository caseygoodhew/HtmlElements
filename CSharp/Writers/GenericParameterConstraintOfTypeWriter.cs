using System;
using Coding;
using Coding.Builder;

namespace CSharp.Writers
{
    public class GenericParameterConstraintOfTypeWriter : Writer, IGenericParameterConstraint
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.GenericConstraint; } }
        
        private readonly IParameterTypeWriter parameterType;
        
        public GenericParameterConstraintOfTypeWriter(IParameterTypeWriter parameterType)
        {
            this.parameterType = parameterType;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                case WriterContext.GenericConstraint:
                    parameterType.Write(builder, WriterContext.ParameterDeclaration);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }
    }
}