namespace Coding.NewFolder1
{
    public class LongWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Long; }
        }
    }
}