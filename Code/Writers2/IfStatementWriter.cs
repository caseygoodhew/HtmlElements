using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class IfStatementWriter : StatementBlockWriter
    {
        internal readonly ConditionWriter Condition;
        
        public IfStatementWriter(ConditionWriter condition)
        {
            Condition = condition;
        }

        protected override void WriteStatement(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.If);
            builder.Add(Token.OpenBracket);
            Condition.Write(builder, context.Switch(WriterContextFlags.Condition));
            builder.Add(Token.CloseBracket);

            base.WriteStatement(builder, context);
        }
    }
}