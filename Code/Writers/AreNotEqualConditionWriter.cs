using Coding.Tokens;

namespace Coding.Writers
{
    public class AreNotEqualConditionWriter : AreEqualConditionWriter
    {
        public AreNotEqualConditionWriter(ValueWriter variableOne, ValueWriter variableTwo) : base(variableOne, variableTwo, Token.NotEqualTo) { }
    }
}