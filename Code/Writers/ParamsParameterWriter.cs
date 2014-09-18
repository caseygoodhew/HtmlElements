using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ParamsParameterWriter : VariableWriter
    {
        public ParamsParameterWriter(TypeWriter type, string name) : base(new ArrayTypeWriter(type), name)
        {
        }

        protected override void WriteType(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.Params);
            base.WriteType(builder, context);
        }

        protected override void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }
    }
}