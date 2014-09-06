namespace Coding.NewFolder1
{
    public abstract class GenericConstraintWriter : Writer
    {
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