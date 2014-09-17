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
        
        protected readonly bool State;

        public BooleanConditionWriter(VariableWriter variable, bool state = true)
        {
            if (!(variable.VariableType is BoolWriter))
            {
                throw new InvalidOperationException("Boolean conditions can only be created for boolean variable types or other conditions");
            }

            Variable = variable;
            State = state;
        }

        public BooleanConditionWriter(ConditionWriter innerCondition, bool state = true)
        {
            State = state;
            InnerCondition = innerCondition;
        }

        internal override void WriteCondition(TokenBuilder builder, WriterContext context)
        {
            if (!State)
            {
                builder.Add(Token.Exclamation);
            }

            if (InnerCondition != null)
            {
                InnerCondition.WriteCondition(builder, context);
            }

            if (Variable != null)
            {
                Variable.Write(builder, context.Switch(WriterContextFlags.VariableName));
            }
        }
    }
}