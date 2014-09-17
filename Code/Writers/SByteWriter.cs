using Coding.Tokens;

namespace Coding.Writers
{
    public class SByteWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.SByte; }
        }
    }
}