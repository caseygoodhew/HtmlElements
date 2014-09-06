namespace Coding.NewFolder1
{
    public class IntWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Int; }
        }
    }
}