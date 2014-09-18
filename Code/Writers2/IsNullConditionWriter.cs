using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class IsNullConditionWriter : ComparableConditionWriter
    {
        protected readonly VariableWriter Variable;

        protected IsNullConditionWriter(VariableWriter variable, Token token) : base(token)
        {
            Variable = variable;   
        }
        
        public IsNullConditionWriter(VariableWriter variable) : this(variable, Token.EqualTo) { }

        protected override void WriteLeftCondition(TokenBuilder builder, WriterContext context)
        {
            Variable.Write(builder, context.Switch(WriterContextFlags.VariableName));
        }

        protected override void WriteRightCondition(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.Null);
        }
    }
}