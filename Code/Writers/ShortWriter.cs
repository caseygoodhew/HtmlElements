using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ShortWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Short; }
        }

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            return value is short;
        }
    }
}