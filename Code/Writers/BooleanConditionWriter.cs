using System;
using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class BooleanConditionWriter : BaseConditionWriter
    {
        protected readonly ValueWriter Variable;

        protected readonly ConditionWriter InnerCondition;
        
        protected readonly bool ExpectedState;

        public BooleanConditionWriter(ValueWriter variable, bool expectedState = true)
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
                if (Variable is VariableWriter)
                {
                    Variable.Write(builder, context.Switch(WriterContextFlags.VariableName));
                }
                else
                {
                    Variable.Write(builder, context.Switch(WriterContextFlags.Value));
                }
            }
        }
    }
}