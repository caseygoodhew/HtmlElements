using Coding.Tokens;

namespace Coding.Writers
{
    public class FloatWriter : ValueTypeWriter
    {
        internal override Token TypeToken
        {
            get { return Token.Float; }
        }
    }
}