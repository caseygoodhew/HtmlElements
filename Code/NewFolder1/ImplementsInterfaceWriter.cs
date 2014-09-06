namespace Coding.NewFolder1
{
    public abstract class ImplementsInterfaceWriter : Writer
    {
        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.ImplementsInterface))
            {
                WriteInterfaceType(builder, context);
                return;
            }
            
            base.Write(builder, context);
        }

        protected abstract void WriteInterfaceType(TokenBuilder builder, WriterContext context);
    }
}