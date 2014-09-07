using Coding.Tokens;

namespace Coding.Writers
{
    public class ByteWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Byte; }
        }
    }
}