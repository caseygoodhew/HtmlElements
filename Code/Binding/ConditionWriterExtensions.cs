using System;
using Coding.Writers;

namespace Coding.Binding
{
    public static class ConditionWriterExtensions
    {
        public static IConditionAndOr IsTrue(this IConditionStatement condition, ValueWriter variable)
        {
            return (condition as ConditionWriter).Add(new BooleanConditionWriter(variable));
        }

        public static IConditionAndOr IsFalse(this IConditionStatement condition, ValueWriter variable)
        {
            return (condition as ConditionWriter).Add(new BooleanConditionWriter(variable, false));
        }

        public static IConditionAndOr IsNull(this IConditionStatement condition, ValueWriter variable)
        {
            return (condition as ConditionWriter).Add(new IsNullConditionWriter(variable));
        }

        public static IConditionAndOr IsNotNull(this IConditionStatement condition, ValueWriter variable)
        {
            return (condition as ConditionWriter).Add(new IsNotNullConditionWriter(variable));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, ValueWriter variableOne, ValueWriter variableTwo)
        {
            return (condition as ConditionWriter).Add(new AreEqualConditionWriter(variableOne, variableTwo));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, bool value)
        {
            return condition.AreEqual(variable, new ValueWriter<bool>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, byte value)
        {
            return condition.AreEqual(variable, new ValueWriter<byte>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, char value)
        {
            return condition.AreEqual(variable, new ValueWriter<char>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, decimal value)
        {
            return condition.AreEqual(variable, new ValueWriter<decimal>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, double value)
        {
            return condition.AreEqual(variable, new ValueWriter<double>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, float value)
        {
            return condition.AreEqual(variable, new ValueWriter<float>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, int value)
        {
            return condition.AreEqual(variable, new ValueWriter<int>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, long value)
        {
            return condition.AreEqual(variable, new ValueWriter<long>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, sbyte value)
        {
            return condition.AreEqual(variable, new ValueWriter<sbyte>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, short value)
        {
            return condition.AreEqual(variable, new ValueWriter<short>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, string value)
        {
            return condition.AreEqual(variable, new ValueWriter<string>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, uint value)
        {
            return condition.AreEqual(variable, new ValueWriter<uint>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, ulong value)
        {
            return condition.AreEqual(variable, new ValueWriter<ulong>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, ushort value)
        {
            return condition.AreEqual(variable, new ValueWriter<ushort>(value));
        }

        public static IConditionAndOr AreEqual(this IConditionStatement condition, VariableWriter variable, Enum value)
        {
            return condition.AreEqual(variable, new ValueWriter<Enum>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, ValueWriter variableOne, ValueWriter variableTwo)
        {
            return (condition as ConditionWriter).Add(new AreNotEqualConditionWriter(variableOne, variableTwo));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, bool value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<bool>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, byte value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<byte>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, char value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<char>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, decimal value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<decimal>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, double value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<double>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, float value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<float>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, int value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<int>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, long value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<long>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, sbyte value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<sbyte>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, short value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<short>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, string value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<string>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, uint value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<uint>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, ulong value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<ulong>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, ushort value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<ushort>(value));
        }

        public static IConditionAndOr AreNotEqual(this IConditionStatement condition, VariableWriter variable, Enum value)
        {
            return condition.AreNotEqual(variable, new ValueWriter<Enum>(value));
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