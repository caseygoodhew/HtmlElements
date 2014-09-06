using System;
using Coding;

namespace CSharp.Writers
{
    public class ExtensionParameterWriter : ParameterWriter
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.ParameterDeclaration; } }

        public ExtensionParameterWriter(IParameterTypeWriter parameterType, string name) : base(parameterType, name)
        {
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                case WriterContext.ParameterDeclaration:
                    WriteParameterDeclaration(builder);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }

        private void WriteParameterDeclaration(TokenBuilder builder)
        {
            builder.Add(Token.This);
            base.Write(builder, WriterContext.ParameterDeclaration);
        }
    }
}
