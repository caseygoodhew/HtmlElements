using System;
using Coding;

namespace CSharp.Writers
{
    public abstract class Writer : IWriter
    {
        internal abstract WriterContext DefaultWriterContext { get; }
        
        public string Write()
        {
            var builder = new TokenBuilder();
            Write(builder, DefaultWriterContext);
            return builder.ToString();
        }

        public abstract void Write(TokenBuilder builder, WriterContext context);
    }
}