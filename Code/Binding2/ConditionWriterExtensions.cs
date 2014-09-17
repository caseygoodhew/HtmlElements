using System;

using Coding.Writers;
using Coding.Writers2;

namespace Coding.Binding2
{
    public static class ConditionWriterExtensions
    {
        public static ConditionWriter IsTrue(this ConditionWriter condition, VariableWriter variable)
        {
            condition.InnerCondition = new BooleanConditionWriter(variable);
            return condition;
        }

        public static ConditionWriter IsFalse(this ConditionWriter condition, VariableWriter variable)
        {
            condition.InnerCondition = new BooleanConditionWriter(variable, false);
            return condition;
        }
    }
}