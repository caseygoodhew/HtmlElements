using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class IsNullConditionWriter : ComparableConditionWriter
    {
        protected readonly ValueWriter Variable;

        protected IsNullConditionWriter(ValueWriter variable, Token token) : base(token)
        {
            Variable = variable;   
        }
        
        public IsNullConditionWriter(ValueWriter variable) : this(variable, Token.EqualTo) { }

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