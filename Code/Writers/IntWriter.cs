using Coding.Tokens;

namespace Coding.Writers
{
    public class IntWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Int; }
        }
    }
}