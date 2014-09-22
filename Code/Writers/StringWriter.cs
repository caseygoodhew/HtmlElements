using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class StringWriter : BuiltInReferenceTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.String; }
        }

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            return value is string;
        }
    }
}
