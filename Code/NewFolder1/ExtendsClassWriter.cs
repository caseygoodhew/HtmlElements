namespace Coding.NewFolder1
{
    public abstract class ExtendsClassWriter : Writer
    {
        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.ExtendsClass))
            {
                WriteClassType(builder, context);
                return;
            }
            
            base.Write(builder, context);
        }

        protected abstract void WriteClassType(TokenBuilder builder, WriterContext context);
    }
}