using Coding.Builder;
using Coding.Writers;

namespace Coding.Writers2
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
            Condition.Write(builder, context);
        }
    }
}