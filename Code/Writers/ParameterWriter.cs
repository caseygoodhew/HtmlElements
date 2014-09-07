using Coding.Builder;

namespace Coding.Writers
{
    public class ParameterWriter : VariableWriter
    {
        public ParameterWriter(VariableTypeWriter variableType, string name) : base(variableType, name)
        {
        }

        protected override void WritePrimaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }

        protected override void WriteSecondaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }

        protected override void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }
    }
}
