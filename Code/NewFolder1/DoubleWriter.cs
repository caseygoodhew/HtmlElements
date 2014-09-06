namespace Coding.NewFolder1
{
    public class DoubleWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Double; }
        }
    }
}