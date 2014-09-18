using System;
using System.Collections.Generic;
using System.Linq;
using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ExternalTypeWriter : TypeWriter
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.VariableType; } }

        internal readonly string Name;
        internal readonly List<TypeWriter> GenericArguments;

        protected ExternalTypeWriter(string name, params TypeWriter[] genericArguments)
        {
            Name = name;
            GenericArguments = genericArguments.ToList();
        }

        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Name);

            if (!GenericArguments.Any())
            {
                return;
            }

            builder.Add(Token.OpenAngle);

            builder.Join(GenericArguments, x => x.Write(builder, context), Token.Comma);
            
            builder.Add(Token.CloseAngle);
        }

        protected internal override bool IsValidType(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
