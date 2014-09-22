using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public abstract class InvokeStatementWriter<TInvokableWriter> : StatementWriter
        where TInvokableWriter : InvokableWriter
    {
        protected override WriterContextFlags DefaultContextFlag
        {
            get
            {
                return WriterContextFlags.Invocation;
            }
        }

        protected readonly TInvokableWriter Invokable;

        protected readonly List<ValueWriter> ParameterValues;

        protected InvokeStatementWriter(List<TInvokableWriter> invokableOptions, List<object> parameterValues)
        {
            ParameterValues = parameterValues.Select(x => new ValueWriter(To.GetTypeWriter(x.GetType()), x)).ToList();
            Invokable = SelectInvokable(invokableOptions, parameterValues);
        }

        private static TInvokableWriter SelectInvokable(
            List<TInvokableWriter> invokableOptions,
            List<object> parameterValues)
        {
            var matchedStats = invokableOptions.Select(x => new InvokableStats(x)).Where(x => x.Matches(parameterValues)).ToList();

            if (matchedStats.Count == 1)
            {
                return matchedStats.First().Invokable as TInvokableWriter;
            }

            if (matchedStats.Count > 1)
            {
                throw new InvokableNotUniqueException(string.Format("Found {0} matching invokables.", matchedStats.Count));
            }
            
            throw new InvokableNotFoundException("Could not find a matching invokable member.");
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.Invocation))
            {
                WriteInvocation(builder, context);
                return;
            }

            base.Write(builder, context);
        }

        protected override void WriteStatement(TokenBuilder builder, WriterContext context)
        {
            WriteInvocation(builder, context.Switch(WriterContextFlags.Invocation));
        }

        protected virtual void WriteInvocation(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Invokable.Name);
            
            builder.Add(Token.OpenBracket);

            builder.Join(ParameterValues, x => x.Write(builder, context.Switch(WriterContextFlags.Value)), Token.Comma);

            builder.Add(Token.CloseBracket);
        }
    }
}
