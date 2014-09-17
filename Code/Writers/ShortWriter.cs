using Coding.Tokens;

namespace Coding.Writers
{
    public class ShortWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Short; }
        }
    }
}