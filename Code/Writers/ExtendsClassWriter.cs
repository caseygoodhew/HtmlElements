using Coding.Builder;

namespace Coding.Writers
{
    public abstract class ExtendsClassWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.ExtendsClass; } }
        
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