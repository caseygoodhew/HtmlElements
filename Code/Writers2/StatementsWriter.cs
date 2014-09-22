using System.Collections.Generic;
using System.Linq;
using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class StatementsWriter : StatementWriter
    {
        internal readonly List<StatementWriter> Statements;

        public StatementsWriter(params StatementWriter[] statements)
        {
            Statements = statements.ToList();
        }

        protected override void WriteStatement(TokenBuilder builder, WriterContext context)
        {
            builder.Join(
                Statements,
                x =>
                    {
                        x.Write(builder, context);
                        if (!(x is StatementBlockWriter))
                        {
                            builder.Add(Token.TerminatingSemiColon);
                        }
                    }, 
                Token.Empty);
        }
    }
}