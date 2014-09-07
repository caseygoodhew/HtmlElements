using System;
using Coding;
using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace CSharp.Writers
{
    public class ClassWriter : WriterWithChildren<IClassChild>, INamespaceChild, IParameterTypeWriter
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.Declaration; } }

        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; }

        public string Name { get; internal set; }

        internal GenericDeclarationWriter GenericDeclaration { get; set; }

        public ClassWriter(string name)
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
                case WriterContext.ParameterDeclaration:
                    builder.Add(Name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }

        private void WriteDeclaration(TokenBuilder builder)
        {
            builder
                .Add(To.Token(PrimaryAccessModifier))
                .Add(To.Token(SecondaryAccessModifier))
                .Add(Token.Class)
                .Add(Name);

            if (GenericDeclaration != null)
            {
                GenericDeclaration.Write(builder, WriterContext.GenericParameter);
                GenericDeclaration.Write(builder, WriterContext.GenericConstraint);
            }

            builder.Add(Token.OpenCurly);

            foreach (var child in SortChildren<PropertyWriter>())
            {
                child.Write(builder, WriterContext.Declaration);
            }

            builder.Add(Token.CloseCurly);
        }
    }
}