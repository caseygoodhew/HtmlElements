using System;
using Coding;
using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace CSharp.Writers
{
    public class EnumWriter : WriterWithChildren<EnumValueWriter>, INamespaceChild
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.Declaration; } }
        
        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        internal string Name { get; set; }

        public EnumWriter(string name)
        {
            Name = name;
            PrimaryAccessModifier = PrimaryAccessModifiers.Public;
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
            builder.Add(To.Token(PrimaryAccessModifier)).Add(Token.Enum).Add(Name);

            builder.Add(Token.OpenCurly);

            builder.Join(Children, x => x.Write(builder, WriterContext.Declaration), Token.TerminatingComma);

            builder.Add(Token.CloseCurly);
        }
    }
}