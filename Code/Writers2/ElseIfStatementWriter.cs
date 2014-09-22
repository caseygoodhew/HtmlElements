using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class ElseIfStatementWriter : StatementBlockWriter
    {
        internal readonly ConditionWriter Condition;
        
        public ElseIfStatementWriter(ConditionWriter condition)
        {
            Condition = condition;
        }

        protected override void WriteStatement(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.ElseIf);
            builder.Add(Token.OpenBracket);
            Condition.Write(builder, context.Switch(WriterContextFlags.Condition));
            builder.Add(Token.CloseBracket);

            base.WriteStatement(builder, context);
        }
    }
}