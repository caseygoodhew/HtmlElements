using System;
using Coding;
using Coding.Builder;

namespace CSharp.Writers
{
    public class ParameterWriter : Writer
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.ParameterDeclaration; } }

        private string Name { get; set; }
        
        private IParameterTypeWriter ParameterType { get; set; }

        public ParameterWriter(IParameterTypeWriter parameterType, string name)
        {
            ParameterType = parameterType;
            Name = name;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                case WriterContext.ParameterDeclaration:
                    WriteDeclaration(builder);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }

        private void WriteDeclaration(TokenBuilder builder)
        {
            ParameterType.Write(builder, WriterContext.ParameterDeclaration);
            builder.Add(Name);
        }
    }
}
