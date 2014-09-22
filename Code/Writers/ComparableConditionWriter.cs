using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public abstract class ComparableConditionWriter : BaseConditionWriter
    {
        protected readonly Token ComparisonToken;

        protected ComparableConditionWriter(Token comparisonToken)
        {
            ComparisonToken = comparisonToken;
        }

        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            WriteLeftCondition(builder, context);
            builder.Add(ComparisonToken);
            WriteRightCondition(builder, context);
        }

        protected abstract void WriteLeftCondition(TokenBuilder builder, WriterContext context);
        
        protected abstract void WriteRightCondition(TokenBuilder builder, WriterContext context);
    }
}