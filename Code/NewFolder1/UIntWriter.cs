namespace Coding.NewFolder1
{
    public class UIntWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.UInt; }
        }
    }
}