using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class BoolWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Bool; }
        }

        protected internal override bool IsValidType(Type type)
        {
            return type == typeof(bool);
        }
    }
}