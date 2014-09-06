using System;
using System.Linq;

using Coding;

namespace CSharp.Writers
{
    public class ModuleWriter : WriterWithChildren<IModuleChild>
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.Declaration; } }
        
        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                case WriterContext.Declaration:
                    WriteDeclaration(builder);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }

        private void WriteDeclaration(TokenBuilder builder)
        {
            Children
                .OfType<UsingWriter>()
                .ToList()
                .ForEach(x => x.Write(builder, WriterContext.Declaration));
            
            builder.Add(Token.EndSection);
            
            Children
                .OfType<NamespaceWriter>()
                .ToList()
                .ForEach(x => x.Write(builder, WriterContext.Declaration));
        }
    }
}