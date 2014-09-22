using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class VariableAssignmentStatementWriter : StatementWriter
    {
        protected readonly VariableWriter Variable;

        protected readonly object Value;

        public VariableAssignmentStatementWriter(VariableWriter variable, object value)
        {
            Variable = variable;
            Value = value;
        }

        protected override void WriteStatement(TokenBuilder builder, WriterContext context)
        {
            Variable.Write(builder, context.Switch(WriterContextFlags.VariableName));

            builder.Add(Token.Equals);

            Variable.Value = Value; 
            Variable.Write(builder, context.Switch(WriterContextFlags.Value));
        }
    }
}