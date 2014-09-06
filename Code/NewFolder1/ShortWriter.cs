namespace Coding.NewFolder1
{
    public class ShortWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Short; }
        }
    }
}