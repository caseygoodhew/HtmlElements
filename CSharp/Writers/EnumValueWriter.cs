using System;
using Coding;

namespace CSharp.Writers
{
    public class EnumValueWriter : Writer
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.Declaration; } }
        
        internal EnumWriter Enum { get; set; }

        internal string Name { get; set; }

        public EnumValueWriter(EnumWriter @enum, string name)
        {
            Enum = @enum;
            Name = name;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                case WriterContext.Declaration:
                    builder.Add(Name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }
    }
}