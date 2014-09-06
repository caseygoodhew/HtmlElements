using System;

namespace Coding.NewFolder1
{
    public abstract class VariableTypeWriter : Writer
    {
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
