using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ConditionTreeLeafWriter : ConditionTreeNodeWriter
    {
        internal readonly BaseConditionWriter Condition;
        
        public ConditionTreeLeafWriter(BaseConditionWriter condition)
        {
            Condition = condition;
        }

        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            var wrap = Condition is ConditionWriter && (Condition as ConditionWriter).Nodes.Count > 1;

            if (wrap)
            {
                builder.Add(Token.OpenBracket);
            }
            
            Condition.Write(builder, context);

            if (wrap)
            {
                builder.Add(Token.CloseBracket);
            }
        }
    }
}