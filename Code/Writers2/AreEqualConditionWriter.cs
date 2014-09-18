using System;
using Coding.Builder;
using Coding.Tokens;
using Coding.Writers;

namespace Coding.Writers2
{
    public class AreEqualConditionWriter : ComparableConditionWriter
    {
        protected readonly object ValueOne;

        protected readonly object ValueTwo;

        private readonly Action<TokenBuilder, WriterContext, object> ValueOneWriter;

        private readonly Action<TokenBuilder, WriterContext, object> ValueTwoWriter;

        public AreEqualConditionWriter(object valueOne, object valueTwo) : this(valueOne, valueTwo, Token.EqualTo) { }

        protected AreEqualConditionWriter(object valueOne, object valueTwo, Token token)
            : base(token)
        {
            ValueOne = valueOne;
            ValueTwo = valueTwo;
            ValueOneWriter = GetValueWriter(valueOne.GetType());
            ValueTwoWriter = GetValueWriter(valueTwo.GetType());
        }

        private Action<TokenBuilder, WriterContext, object> GetValueWriter(Type type)
        {
            if (type.IsEnum)
            {
                return (b, c, o) =>
                {
                    b.Add(o.GetType().Name);
                    b.Add(Token.Dot);
                    b.Add(o.ToString());
                };
            }

            if ((type.IsValueType && type.IsPrimitive) || type == typeof(string))
            {
                return (b, c, o) => b.Add(o.ToString());
            }

            if (type == typeof(VariableWriter))
            {
                return (b, c, o) => (o as VariableWriter).Write(b, c);
            }

            if (type == typeof(EnumValueWriter))
            {
                return (b, c, o) => (o as EnumValueWriter).Write(b, c);
            }
            
            throw new InvalidOperationException("This condition writer does not know how to deal with " + type.Name);
        }

        protected override void WriteLeftCondition(TokenBuilder builder, WriterContext context)
        {
            ValueOneWriter.Invoke(builder, context.Switch(WriterContextFlags.VariableName), ValueOne);
        }

        protected override void WriteRightCondition(TokenBuilder builder, WriterContext context)
        {
            ValueTwoWriter.Invoke(builder, context.Switch(WriterContextFlags.VariableName), ValueTwo);
        }
    }
}