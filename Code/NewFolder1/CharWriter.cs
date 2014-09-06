namespace Coding.NewFolder1
{
    public class CharWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Char; }
        }
    }
}