using Coding.Builder;

namespace Coding.Writers
{
    public abstract class GenericConstraintWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.GenericConstraints; } }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.GenericConstraints))
            {
                WriteGenericConstraint(builder, context);
                return;
            }
            
            base.Write(builder, context);
        }

        protected abstract void WriteGenericConstraint(TokenBuilder builder, WriterContext context);
    }
}