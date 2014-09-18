using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class DoubleWriter : BuiltinValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Double; }
        }

        protected internal override bool IsValidType(Type type)
        {
            return type == typeof(double);
        }
    }
}