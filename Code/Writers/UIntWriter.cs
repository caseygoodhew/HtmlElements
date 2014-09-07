using Coding.Tokens;

namespace Coding.Writers
{
    public class UIntWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.UInt; }
        }
    }
}