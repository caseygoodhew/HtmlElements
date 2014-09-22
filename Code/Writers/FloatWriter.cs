using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class FloatWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Float; }
        }

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            return value is float;
        }
    }
}