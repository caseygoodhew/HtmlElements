using Coding.Tokens;

namespace Coding.Writers
{
    public class DynamicWriter : BuiltInReferenceTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Dynamic; }
        }
    }
}
