namespace Coding.NewFolder1
{
    public class DecimalWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Decimal; }
        }
    }
}