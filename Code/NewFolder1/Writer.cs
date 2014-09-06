using System;

namespace Coding.NewFolder1
{
    public abstract class Writer : IWriter
    {
        public virtual void Write(TokenBuilder builder, WriterContext context)
        {
            throw new InvalidOperationException();
        }
    }
}