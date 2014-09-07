using Coding.Builder;

namespace Coding.Writers
{
    public abstract class VariableTypeWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.VariableType; } }
        
        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.VariableType))
            {
                WriteTypeName(builder, context);
                return;
            }
            
            base.Write(builder, context);
        }

        protected abstract void WriteTypeName(TokenBuilder builder, WriterContext context);
    }
}
