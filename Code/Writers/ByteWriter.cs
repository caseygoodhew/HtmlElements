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

        protected internal override bool IsValidType(Type type)
        {
            return type == typeof(byte);
        }
    }
}