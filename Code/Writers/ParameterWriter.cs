using System;

using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ParameterWriter : VariableWriter
    {
        protected readonly bool HasDefaultValue;
        
        public ParameterWriter(TypeWriter type, string name) : base(type, name)
        {
            HasDefaultValue = false;
        }

        public ParameterWriter(TypeWriter type, string name, object defaultValue) : base(type, name, defaultValue)
        {
            if (!type.IsValidValue(defaultValue, true))
            {
                throw new InvalidOperationException(string.Format("{0} is not a valid default parameter value.", defaultValue));
            }

            HasDefaultValue = true;
        }

        protected override void WriteSetValue(TokenBuilder builder, WriterContext context)
        {
            if (!HasDefaultValue)
            {
                return;
            }

            builder.Add(Token.Equals);
            WriteValue(builder, context);
        }

        protected override void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }       
    }
}
