using Coding.Tokens;

namespace Coding.Writers
{
    public class BoolWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Bool; }
        }
    }
}