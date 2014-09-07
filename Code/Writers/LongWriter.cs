using Coding.Tokens;

namespace Coding.Writers
{
    public class LongWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Long; }
        }
    }
}