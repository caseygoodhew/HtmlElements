using Coding.Builder;

namespace Coding.Writers
{
    public class ParameterWriter : VariableWriter
    {
        public ParameterWriter(TypeWriter type, string name) : base(type, name)
        {
        }

        protected override void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }
    }
}
