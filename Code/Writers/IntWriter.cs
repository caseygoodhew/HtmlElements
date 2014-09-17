using Coding.Tokens;

namespace Coding.Writers
{
    public class IntWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Int; }
        }
    }
}