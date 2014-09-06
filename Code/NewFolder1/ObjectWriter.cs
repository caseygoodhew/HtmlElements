namespace Coding.NewFolder1
{
    public class ObjectWriter : BuiltInReferenceTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Object; }
        }
    }
}
