using System.Collections.Generic;
using System.Linq;

namespace Coding.NewFolder1
{
    public class GenericParameterWriter : VariableTypeWriter
    {
        internal readonly string Name;

        internal readonly List<GenericConstraintWriter> GenericConstraints;
        
        public GenericParameterWriter(string name, params GenericConstraintWriter[] genericConstraints)
        {
            Name = name;
            GenericConstraints = genericConstraints.ToList();
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
            if (!GenericConstraints.Any())
            {
                return;
            }

            builder.Add(Token.Where)
                    .Add(Name)
                    .Add(Token.Colon);

            builder.Join(GenericConstraints, x => x.Write(builder, context), Token.Comma);
        }
    }
}
