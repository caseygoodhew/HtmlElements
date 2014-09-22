using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ObjectWriter : BuiltInReferenceTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Object; }
        }

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            return !asParameterDefault || value == null;
        }
    }
}
