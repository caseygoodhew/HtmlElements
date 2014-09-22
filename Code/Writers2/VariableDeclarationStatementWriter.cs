using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class VariableDeclarationStatementWriter : StatementWriter
    {
        protected readonly VariableWriter Variable;
        
        public VariableDeclarationStatementWriter(VariableWriter variable)
        {
            Variable = variable;
        }

        protected override void WriteStatement(TokenBuilder builder, WriterContext context)
        {
            Variable.Write(builder, context.Switch(WriterContextFlags.VariableType));
            
            Variable.Write(builder, context.Switch(WriterContextFlags.VariableName));

            if (Variable.Value != null)
            {
                builder.Add(Token.Equals);
                Variable.Write(builder, context.Switch(WriterContextFlags.Value));
            }
        }
    }
}