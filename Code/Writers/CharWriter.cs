using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class CharWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Char; }
        }
        
        protected internal override bool IsValidType(Type type)
        {
            return type == typeof(char);
        }
    }
}