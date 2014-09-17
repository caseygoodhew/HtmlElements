using System.Collections.Generic;
using System.Linq;
using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ExternalVariableTypeWriter : VariableTypeWriter
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.VariableType; } }

        internal readonly string Name;
        internal readonly List<VariableTypeWriter> GenericArguments;

        protected ExternalVariableTypeWriter(string name, params VariableTypeWriter[] genericArguments)
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
    }
}
