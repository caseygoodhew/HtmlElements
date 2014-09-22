using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class ElseStatementWriter : StatementBlockWriter
    {
        protected override void WriteStatement(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.Else);
            
            base.WriteStatement(builder, context);
        }
    }
}