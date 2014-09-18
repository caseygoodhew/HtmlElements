using System;
using Coding.Writers;
using Coding.Writers2;

namespace Coding.Binding2
{
    public static class ConditionWriterExtensions
    {
        public static IConditionAndOr IsTrue(this IConditionStatement condition, VariableWriter variable)
        {
            return (condition as ConditionWriter).Add(new BooleanConditionWriter(variable));
        }

        public static IConditionAndOr IsFalse(this IConditionStatement condition, VariableWriter variable)
        {
            return (condition as ConditionWriter).Add(new BooleanConditionWriter(variable, false));
        }

        public static IConditionAndOr IsNull(this IConditionStatement condition, VariableWriter variable)
        {
            return (condition as ConditionWriter).Add(new IsNullConditionWriter(variable));
        }

        public static IConditionAndOr IsNotNull(this IConditionStatement condition, VariableWriter variable)
        {
            return (condition as ConditionWriter).Add(new IsNotNullConditionWriter(variable));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variableOne, VariableWriter variableTwo)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variableOne, variableTwo));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, bool value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, byte value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, char value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, decimal value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, double value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, float value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, int value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, long value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, sbyte value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, short value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, string value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, uint value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, ulong value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, ushort value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, Enum value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, EnumValueWriter value)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variable, value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variableOne, VariableWriter variableTwo)
        {
            return (condition as ConditionWriter).Add(new AreNotEqualConditionWriter(variableOne, variableTwo));
        }

        public static IConditionStatement And(this IConditionAndOr condition)
        {
            return (condition as ConditionWriter).Add(new ConditionTreeAndWriter());
        }

        public static IConditionStatement Or(this IConditionAndOr condition)
        {
            return (condition as ConditionWriter).Add(new ConditionTreeOrWriter());
        }

        public static IConditionAndOr And(this IConditionAndOr condition, Action<ConditionWriter> configAction)
        {
            var subCondition = new ConditionWriter();
            
            configAction.Invoke(subCondition);

            return (condition as ConditionWriter).Add(new ConditionTreeAndWriter()).Add(subCondition);
        }

        public static IConditionAndOr Or(this IConditionAndOr condition, Action<ConditionWriter> configAction)
        {
            var subCondition = new ConditionWriter();
            
            configAction.Invoke(subCondition);

            return (condition as ConditionWriter).Add(new ConditionTreeOrWriter()).Add(subCondition);
        }

        private static ConditionWriter Add(this ConditionWriter condition, BaseConditionWriter newCondition)
        {
            return condition.Add(new ConditionTreeLeafWriter(newCondition));
        }

        private static ConditionWriter Add(this ConditionWriter condition, ConditionTreeNodeWriter conditionNode)
        {
            condition.Nodes.Add(conditionNode);
            return condition;
        }
    }
}