namespace Coding.NewFolder1
{
    public class FloatWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Float; }
        }
    }
}