using Coding.Builder;
using Coding.Writers2;

namespace Coding.Writers
{
    public abstract class BaseConditionWriter : StatementWriter
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

        protected override void WriteStatement(TokenBuilder builder, WriterContext context)
        {
            WriteCondition(builder, context.Switch(WriterContextFlags.Condition));
        }

        protected abstract void WriteCondition(TokenBuilder builder, WriterContext context);
    }
}