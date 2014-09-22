using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ArrayTypeWriter : TypeWriter
    {
        internal readonly TypeWriter Type;

        public ArrayTypeWriter(TypeWriter type)
        {
            Type = type;
        }

        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            Type.Write(builder, context);
            builder.Add(Token.OpenSquare);
            builder.Add(Token.CloseSquare);
        }

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            return value == null || (!asParameterDefault && value.GetType().IsArray);
        }
    }
}