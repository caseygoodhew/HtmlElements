using Coding.Tokens;

namespace Coding.Writers
{
    public class ShortWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Short; }
        }
    }
}