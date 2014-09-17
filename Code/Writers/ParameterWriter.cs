using Coding.Builder;

namespace Coding.Writers
{
    public class ParameterWriter : VariableWriter
    {
        public ParameterWriter(VariableTypeWriter variableType, string name) : base(variableType, name)
        {
        }

        protected override void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }
    }
}
