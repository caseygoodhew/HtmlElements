using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class ConditionTreeAndWriter : ConditionTreeNodeWriter
    {
        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.ConditionalAnd);
        }
    }
}