using Coding.Tokens;

namespace Coding.Writers
{
    public class UIntWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.UInt; }
        }
    }
}