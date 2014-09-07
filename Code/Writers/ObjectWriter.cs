using Coding.Tokens;

namespace Coding.Writers
{
    public class ObjectWriter : BuiltInReferenceTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Object; }
        }
    }
}
