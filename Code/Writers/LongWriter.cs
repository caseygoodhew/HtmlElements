using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class LongWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Long; }
        }

        protected internal override bool IsValidType(Type type)
        {
            return type == typeof(long);
        }
    }
}