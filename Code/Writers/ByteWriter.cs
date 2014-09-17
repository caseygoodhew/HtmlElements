using Coding.Tokens;

namespace Coding.Writers
{
    public class ByteWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Byte; }
        }
    }
}