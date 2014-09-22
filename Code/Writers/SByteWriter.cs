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

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            return value is sbyte;
        }
    }
}