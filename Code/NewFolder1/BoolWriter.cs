namespace Coding.NewFolder1
{
    public class BoolWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Bool; }
        }
    }
}