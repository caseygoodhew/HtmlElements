namespace Coding.NewFolder1
{
    public class ByteWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Byte; }
        }
    }
}