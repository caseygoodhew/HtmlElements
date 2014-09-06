namespace Coding.NewFolder1
{
    public class SByteWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.SByte; }
        }
    }
}