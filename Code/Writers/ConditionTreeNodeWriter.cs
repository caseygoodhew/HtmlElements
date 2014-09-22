using Coding.Builder;

namespace Coding.Writers
{
    public abstract class ConditionTreeNodeWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.Condition; } }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.Condition))
            {
                WriteCondition(builder, context);
                return;
            }

            base.Write(builder, context);
        }

        protected abstract void WriteCondition(TokenBuilder builder, WriterContext context);
    }
}