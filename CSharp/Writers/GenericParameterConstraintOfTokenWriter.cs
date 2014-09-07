using System;
using Coding;
using Coding.Builder;
using Coding.Tokens;

namespace CSharp.Writers
{
    public class GenericParameterConstraintOfTokenWriter : Writer, IGenericParameterConstraint
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.GenericConstraint; } }
        
        internal readonly Token Token;
        
        public GenericParameterConstraintOfTokenWriter(Token token)
        {
            Token = token;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                case WriterContext.GenericConstraint:
                    builder.Add(Token);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }
    }
}