namespace Coding.NewFolder1
{
    public class StringWriter : BuiltInReferenceTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.String; }
        }
    }
}
