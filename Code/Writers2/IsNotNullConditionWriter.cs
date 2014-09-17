using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class IsNotNullConditionWriter : IsNullConditionWriter
    {
        public IsNotNullConditionWriter(VariableWriter variable) : base(variable, Token.NotEqualTo)
        {
        }
    }
}