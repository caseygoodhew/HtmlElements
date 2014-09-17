using Coding.Builder;
using Coding.Writers;

namespace Coding.Writers2
{
    public abstract class BaseConditionWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.Statement; } }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.Statement))
            {
                WriteCondition(builder, context);
                return;
            }

            base.Write(builder, context);
        }

        internal abstract void WriteCondition(TokenBuilder builder, WriterContext context);
    }
}