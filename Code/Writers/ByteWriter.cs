using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ByteWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Byte; }
        }

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            return value is byte;
        }
    }
}