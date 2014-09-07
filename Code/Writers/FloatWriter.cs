using Coding.Tokens;

namespace Coding.Writers
{
    public class FloatWriter : ValueTypeWriter
    {
        public override Token TypeToken
        {
            get { return Token.Float; }
        }
    }
}