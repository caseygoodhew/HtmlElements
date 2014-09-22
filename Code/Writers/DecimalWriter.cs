using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class DecimalWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Decimal; }
        }

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            return value is decimal;
        }
    }
}