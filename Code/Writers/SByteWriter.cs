using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class SByteWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.SByte; }
        }

        protected internal override bool IsValidType(Type type)
        {
            return type == typeof(sbyte);
        }
    }
}