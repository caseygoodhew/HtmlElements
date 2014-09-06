using System;
using System.Collections.Generic;
using System.Linq;
using Coding;

namespace CSharp.Writers
{
    public class MethodWriter : WriterWithChildren<IMethodChild>, IClassChild
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.Declaration; } }
        
        internal PrimaryAccessModifiers AccessModifier { get; set; }

        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; }

        public string Name { get; internal set; }

        internal GenericDeclarationWriter GenericDeclaration { get; set; }
        
        internal List<ParameterWriter> Parameters { get; set; }

        internal ExtensionParameterWriter ExtensionParameter { get; set; }
        
        internal IParameterTypeWriter ReturnType { get; set; }

        public MethodWriter(string name)
        {
            Name = name;
            AccessModifier = PrimaryAccessModifiers.Public;
            Parameters = new List<ParameterWriter>();
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
            builder.Add(To.Token(AccessModifier))
                .Add(To.Token(SecondaryAccessModifier));

            if (ReturnType == null)
            {
                builder.Add(Token.Void);
            }
            else
            {
                ReturnType.Write(builder, WriterContext.ParameterDeclaration);
            }

            builder.Add(Name);

            if (GenericDeclaration != null)
            {
                GenericDeclaration.Write(builder, WriterContext.GenericParameter);
            }

            var parameters = Parameters;
            if (ExtensionParameter != null)
            {
                parameters = new[] { ExtensionParameter as ParameterWriter }.Concat(parameters).ToList();
            }

            builder.Add(Token.OpenBracket)
                .Join(parameters, x => x.Write(builder, WriterContext.ParameterDeclaration), Token.Comma)
                .Add(Token.CloseBracket);

            if (GenericDeclaration != null)
            {
                GenericDeclaration.Write(builder, WriterContext.GenericConstraint);
            }

            if (SecondaryAccessModifier == SecondaryAccessModifiers.Abstract)
            {
                builder.Add(Token.TerminatingSemiColon);
            }
            else
            {
                builder.Add(Token.OpenCurly)
                    .Join(Children, x => x.Write(builder, WriterContext.Declaration), Token.NewLine)
                    .Add(Token.CloseCurly);   
            }
        }
    }
}
