using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ULongWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.ULong; }
        }

        protected internal override bool IsValidType(Type type)
        {
            return type == typeof(ulong);
        }
    }
}