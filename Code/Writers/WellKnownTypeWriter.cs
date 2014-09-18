using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public abstract class WellKnownTypeWriter : TypeWriter
    {
        internal abstract Token TypeToken { get; }

        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(TypeToken);
        }
    }
}
