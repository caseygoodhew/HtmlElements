using Coding.Tokens;

namespace Coding.Writers
{
    public class StringWriter : BuiltInReferenceTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.String; }
        }
    }
}
