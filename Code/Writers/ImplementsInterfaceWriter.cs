using Coding.Builder;

namespace Coding.Writers
{
    public abstract class ImplementsInterfaceWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.ImplementsInterface; } }
        
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