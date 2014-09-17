using Coding.Tokens;

namespace Coding.Writers
{
    public class DecimalWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Decimal; }
        }
    }
}