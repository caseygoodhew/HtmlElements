using Coding.Tokens;

namespace Coding.Writers
{
    public class DoubleWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Double; }
        }
    }
}