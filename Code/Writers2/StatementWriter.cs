using Coding.Builder;
using Coding.Writers;

namespace Coding.Writers2
{
    public abstract class StatementWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.Statement; } }
        
        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.Statement))
            {
                WriteStatement(builder, context);
                return;
            }
            
            base.Write(builder, context);
        }

        protected abstract void WriteStatement(TokenBuilder builder, WriterContext context);
    }
}
