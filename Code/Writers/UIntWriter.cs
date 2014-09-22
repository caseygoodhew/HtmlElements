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

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            return value is uint;
        }
    }
}