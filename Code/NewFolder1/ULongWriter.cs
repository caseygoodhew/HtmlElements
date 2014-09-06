namespace Coding.NewFolder1
{
    public class ULongWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.ULong; }
        }
    }
}