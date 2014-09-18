using Coding.Tokens;

namespace Coding.Writers2
{
    public class AreNotEqualConditionWriter : AreEqualConditionWriter
    {
        public AreNotEqualConditionWriter(object valueOne, object valueTwo) : base(valueOne, valueTwo, Token.NotEqualTo) { }
    }
}