using Coding.Tokens;

namespace Coding.Writers
{
    public class ObjectWriter : BuiltInReferenceTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Object; }
        }
    }
}
