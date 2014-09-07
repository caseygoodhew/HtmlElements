using System;
using Coding;
using Coding.Builder;
using Coding.Tokens;

namespace CSharp.Writers
{
    public class NamespaceWriter : WriterWithChildren<INamespaceChild>, IModuleChild
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.Declaration; } }
        
        internal string Name { get; set; }

        public NamespaceWriter(string name)
        {
            Name = name;
        }

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
            builder.Add(Token.Namespace).Add(Name);
            builder.Add(Token.OpenCurly);

            foreach (var child in SortChildren<EnumWriter, InterfaceWriter, ClassWriter>())
            {
                child.Write(builder, WriterContext.Declaration);
            }

            builder.Add(Token.CloseCurly);
        }
    }
}