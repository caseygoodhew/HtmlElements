using Coding.Tokens;

namespace Coding.Writers
{
    public class StringWriter : BuiltInReferenceTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.String; }
        }
    }
}
