using Coding.Tokens;

namespace Coding.Writers
{
    public class ULongWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.ULong; }
        }
    }
}