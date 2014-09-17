using Coding.Tokens;

namespace Coding.Writers
{
    public class UShortWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.UShort; }
        }
    }
}