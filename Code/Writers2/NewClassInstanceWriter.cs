using System.Linq;

using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class NewClassInstanceWriter : InvokeStatementWriter<ConstructorWriter>
    {
        protected readonly ClassWriter Class;

        public NewClassInstanceWriter(ClassWriter @class, params object[] parameters)
            : base(@class.Constructors, parameters.ToList())
        {
            Class = @class;
        }

        protected override void WriteInvocation(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.New);
            base.WriteInvocation(builder, context);
        }
    }
}