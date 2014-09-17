using Coding.Tokens;

namespace Coding.Writers
{
    public class DoubleWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Double; }
        }
    }
}