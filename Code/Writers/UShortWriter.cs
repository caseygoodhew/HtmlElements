using Coding.Tokens;

namespace Coding.Writers
{
    public class UShortWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.UShort; }
        }
    }
}