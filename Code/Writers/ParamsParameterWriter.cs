using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ParamsParameterWriter : VariableWriter
    {
        public ParamsParameterWriter(VariableTypeWriter variableType, string name) : base(new ArrayVariableTypeWriter(variableType), name)
        {
        }

        protected override void WriteVariableType(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.Params);
            base.WriteVariableType(builder, context);
        }

        protected override void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }
    }
}