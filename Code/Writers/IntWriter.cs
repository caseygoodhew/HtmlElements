using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class IntWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Int; }
        }

        protected internal override bool IsValidType(Type type)
        {
            return type == typeof(int);
        }
    }
}