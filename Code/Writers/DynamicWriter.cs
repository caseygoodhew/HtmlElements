using System;
using Coding.Tokens;

namespace Coding.Writers
{
    public class DynamicWriter : BuiltInReferenceTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Dynamic; }
        }

        protected internal override bool IsValidType(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
