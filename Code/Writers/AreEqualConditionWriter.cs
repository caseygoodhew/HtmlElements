using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class AreEqualConditionWriter : ComparableConditionWriter
    {
        protected readonly ValueWriter VariableOne;

        protected readonly ValueWriter VariableTwo;

        public AreEqualConditionWriter(ValueWriter variableOne, ValueWriter variableTwo) : this(variableOne, variableTwo, Token.EqualTo) { }

        protected AreEqualConditionWriter(ValueWriter variableOne, ValueWriter variableTwo, Token token) : base(token)
        {
            VariableOne = variableOne;
            VariableTwo = variableTwo;
        }
        
        protected override void WriteLeftCondition(TokenBuilder builder, WriterContext context)
        {
            if (VariableOne is VariableWriter)
            {
                VariableOne.Write(builder, context.Switch(WriterContextFlags.VariableName));    
            }
            else
            {
                VariableOne.Write(builder, context.Switch(WriterContextFlags.Value));
            }
        }

        protected override void WriteRightCondition(TokenBuilder builder, WriterContext context)
        {
            if (VariableTwo is VariableWriter)
            {
                VariableTwo.Write(builder, context.Switch(WriterContextFlags.VariableName));
            }
            else
            {
                VariableTwo.Write(builder, context.Switch(WriterContextFlags.Value));
            }
        }
    }
}