using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class UIntWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.UInt; }
        }

        protected internal override bool IsValidType(Type type)
        {
            return type == typeof(uint);
        }
    }
}