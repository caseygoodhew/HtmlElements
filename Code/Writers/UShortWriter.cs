using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class UShortWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.UShort; }
        }

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            return value is ushort;
        }
    }
}