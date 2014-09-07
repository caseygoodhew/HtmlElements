using Coding.Tokens;

namespace Coding.Writers
{
    public class ULongWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.ULong; }
        }
    }
}