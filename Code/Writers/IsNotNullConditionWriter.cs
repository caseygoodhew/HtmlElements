using Coding.Tokens;

namespace Coding.Writers
{
    public class IsNotNullConditionWriter : IsNullConditionWriter
    {
        public IsNotNullConditionWriter(ValueWriter variable) : base(variable, Token.NotEqualTo)
        {
        }
    }
}