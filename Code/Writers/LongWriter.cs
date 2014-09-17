using Coding.Tokens;

namespace Coding.Writers
{
    public class LongWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Long; }
        }
    }
}