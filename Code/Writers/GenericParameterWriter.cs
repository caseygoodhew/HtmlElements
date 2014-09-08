using System.Collections.Generic;
using System.Linq;

using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class GenericParameterWriter : VariableTypeWriter
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.GenericParameter; } }
        
        internal readonly string Name;

        internal readonly List<GenericConstraintWriter> Constraints;
        
        public GenericParameterWriter(string name, params GenericConstraintWriter[] genericConstraints)
        {
            Name = name;
            Constraints = genericConstraints.ToList();
        }
        
        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.GenericParameter))
            {
                WriteTypeName(builder, context);
                return;
            }

            if (context.Is(WriterContextFlags.GenericConstraints))
            {
                WriteGenericConstraints(builder, context);
                return;
            }

            base.Write(builder, context);
        }
        
        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Name);
        }

        private void WriteGenericConstraints(TokenBuilder builder, WriterContext context)
        {
            if (!Constraints.Any())
            {
                return;
            }

            builder.Add(Token.Where)
                    .Add(Name)
                    .Add(Token.Colon);

            builder.Join(Constraints, x => x.Write(builder, context), Token.Comma);
        }
    }
}
