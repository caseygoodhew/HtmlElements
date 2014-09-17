using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class AreNotEqualConditionWriter : AreEqualConditionWriter
    {
        public AreNotEqualConditionWriter(VariableWriter variableOne, VariableWriter variableTwo) : base(variableOne, variableTwo, Token.NotEqualTo)
        {
        }
    }
}