using System;
using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class BooleanConditionWriter : BaseConditionWriter
    {
        protected readonly VariableWriter Variable;

        protected readonly ConditionWriter InnerCondition;
        
        protected readonly bool ExpectedState;

        public BooleanConditionWriter(VariableWriter variable, bool expectedState = true)
        {
            if (!(variable.Type is BoolWriter))
            {
                throw new InvalidOperationException("Boolean conditions can only be created for boolean variable types or other conditions");
            }

            Variable = variable;
            ExpectedState = expectedState;
        }

        public BooleanConditionWriter(ConditionWriter innerCondition, bool expectedState = true)
        {
            ExpectedState = expectedState;
            InnerCondition = innerCondition;
        }

        protected override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            if (!ExpectedState)
            {
                builder.Add(Token.Exclamation);
            }

            if (InnerCondition != null)
            {
                InnerCondition.Write(builder, context);
            }

            if (Variable != null)
            {
                Variable.Write(builder, context.Switch(WriterContextFlags.VariableName));
            }
        }
    }
}