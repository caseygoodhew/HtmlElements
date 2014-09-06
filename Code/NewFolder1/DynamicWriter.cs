namespace Coding.NewFolder1
{
    public class DynamicWriter : BuiltInReferenceTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Dynamic; }
        }
    }
}
