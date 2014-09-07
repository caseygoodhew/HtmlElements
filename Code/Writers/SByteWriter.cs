using Coding.Tokens;

namespace Coding.Writers
{
    public class SByteWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.SByte; }
        }
    }
}