using System;
using Coding;
using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace CSharp.Writers
{
    public class FieldWriter : Writer, IClassChild, IInterfaceChild, IParameterTypeWriter
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.Declaration; } }
        
        public string Name { get; internal set; }

        internal IParameterTypeWriter FieldType { get; set; }

        internal PrimaryAccessModifiers AccessModifier { get; set; }

        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; }

        public FieldWriter(IParameterTypeWriter fieldType, string name)
        {
            FieldType = fieldType;
            Name = name;
            AccessModifier = PrimaryAccessModifiers.Public;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                case WriterContext.Declaration:
                    WriteDeclaration(builder);
                    break;
                case WriterContext.ParameterDeclaration:
                    builder.Add(Name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }

        private void WriteDeclaration(TokenBuilder builder)
        {
            builder.Add(To.Token(AccessModifier))
                .Add(To.Token(SecondaryAccessModifier));

            FieldType.Write(builder, WriterContext.ParameterDeclaration);

            builder.Add(Name)
                .Add(Token.TerminatingSemiColon);
        }
    }
}
