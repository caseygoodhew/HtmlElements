using Coding.Tokens;

namespace Coding.Writers
{
    public class DecimalWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Decimal; }
        }
    }
}