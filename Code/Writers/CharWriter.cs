using Coding.Tokens;

namespace Coding.Writers
{
    public class CharWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Char; }
        }
    }
}