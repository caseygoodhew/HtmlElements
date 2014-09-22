using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class StatementBlockWriter : StatementsWriter
    {
        protected override void WriteStatement(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.OpenCurly);
            base.WriteStatement(builder, context);
            builder.Add(Token.CloseCurly);
        }
    }
}