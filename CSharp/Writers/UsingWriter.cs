using System;
using Coding;
using Coding.Builder;
using Coding.Tokens;

namespace CSharp.Writers
{
    public class UsingWriter : Writer, IModuleChild
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.Declaration; } }

        internal NamespaceWriter Namespace { get; set; }

        public UsingWriter(string @namespace)
        {
            Namespace = new NamespaceWriter(@namespace);
        }

        public UsingWriter(NamespaceWriter @namespace)
        {
            Namespace = @namespace;
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
            builder.Add(Token.Using)
                       .Add(Namespace.Name)
                       .Add(Token.TerminatingSemiColon);
        }
    }
}