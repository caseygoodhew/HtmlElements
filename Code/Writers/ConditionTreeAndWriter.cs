using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ConditionTreeAndWriter : ConditionTreeNodeWriter
    {
        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.ConditionalAnd);
        }
    }
}