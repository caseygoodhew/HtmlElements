using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class AreEqualConditionWriter : ComparableConditionWriter
    {
        protected readonly VariableWriter VariableOne;

        protected readonly VariableWriter VariableTwo;

        protected AreEqualConditionWriter(VariableWriter variableOne, VariableWriter variableTwo, Token token) : base(token)
        {
            VariableOne = variableOne;
            VariableTwo = variableTwo;   
        }

        public AreEqualConditionWriter(VariableWriter variableOne, VariableWriter variableTwo) : this(variableOne, variableTwo, Token.EqualTo) { }

        protected override void WriteLeftCondition(TokenBuilder builder, WriterContext context)
        {
            VariableOne.Write(builder, context);
        }

        protected override void WriteRightCondition(TokenBuilder builder, WriterContext context)
        {
            VariableTwo.Write(builder, context);
        }
    }
}