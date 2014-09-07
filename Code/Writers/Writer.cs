using System;

using Coding.Builder;

namespace Coding.Writers
{
    public abstract class Writer : IWriter
    {
        protected abstract WriterContextFlags DefaultContextFlag { get; }

        public string Write()
        {
            var builder = new TokenBuilder();
            var context = new WriterContext(DefaultContextFlag);
            
            Write(builder, context);
            
            return builder.ToString();
        }

        public virtual void Write(TokenBuilder builder, WriterContext context)
        {
            throw new InvalidOperationException();
        }
        
        public T Clone<T>() where T : Writer
        {
            return MemberwiseClone() as T;
        }
    }
}