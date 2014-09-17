using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public abstract class ComparableConditionWriter : BaseConditionWriter
    {
        protected readonly Token ComparisonToken;

        protected ComparableConditionWriter(Token comparisonToken)
        {
            ComparisonToken = comparisonToken;
        }

        internal override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            WriteLeftCondition(builder, context);
            builder.Add(ComparisonToken);
            WriteRightCondition(builder, context);
        }

        protected abstract void WriteLeftCondition(TokenBuilder builder, WriterContext context);
        
        protected abstract void WriteRightCondition(TokenBuilder builder, WriterContext context);
    }
}