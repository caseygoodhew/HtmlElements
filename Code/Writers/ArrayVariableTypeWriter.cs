using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ArrayVariableTypeWriter : VariableTypeWriter
    {
        internal readonly VariableTypeWriter VariableType;

        public ArrayVariableTypeWriter(VariableTypeWriter variableType)
        {
            VariableType = variableType;
        }

        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            VariableType.Write(builder, context);
            builder.Add(Token.OpenSquare);
            builder.Add(Token.CloseSquare);
        }
    }
}