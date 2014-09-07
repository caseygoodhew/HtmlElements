using Coding.Tokens;

namespace Coding.Writers
{
    public class BoolWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Bool; }
        }
    }
}