using System;
using System.Collections.Generic;
using System.Linq;

using Coding;
using Coding.Builder;
using Coding.Tokens;

namespace CSharp.Writers
{
    public class GenericDeclarationWriter : WriterWithChildren<GenericParameterWriter>, IInterfaceChild, IClassChild, IMethodChild
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.GenericParameter; } }
        
        public GenericDeclarationWriter(IEnumerable<GenericParameterWriter> parameters = null)
        {
            if (parameters != null)
            {
                Children.AddRange(parameters);
            }
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                case WriterContext.GenericParameter:
                    WriteParameters(builder);
                    break;
                case WriterContext.GenericConstraint:
                    WriteConstraints(builder);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }

        private void WriteParameters(TokenBuilder builder)
        {
            builder.Add(Token.OpenAngle)
                .Join(Children, x => x.Write(builder, WriterContext.GenericParameter), Token.Comma)
                .Add(Token.CloseAngle);
        }

        private void WriteConstraints(TokenBuilder builder)
        {
            builder.Join(Children.Where(x => x.Constraints.Any()), x =>
            {
                builder.Add(Token.Where)
                    .Add(x.Name)
                    .Add(Token.Colon);

                x.Write(builder, WriterContext.GenericConstraint);
            
            }, Token.Empty);
        }
    }
}