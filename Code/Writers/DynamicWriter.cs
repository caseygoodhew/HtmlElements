using Coding.Tokens;

namespace Coding.Writers
{
    public class DynamicWriter : BuiltInReferenceTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Dynamic; }
        }
    }
}
