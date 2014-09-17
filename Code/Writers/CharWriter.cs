using Coding.Tokens;

namespace Coding.Writers
{
    public class CharWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Char; }
        }
    }
}