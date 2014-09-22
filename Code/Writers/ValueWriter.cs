using System;
using Coding.Builder;
using Coding.Tokens;
using Coding.Writers2;

namespace Coding.Writers
{
    public class ValueWriter<T> : ValueWriter
    {
        public ValueWriter() : base(To.GetTypeWriter<T>())
        {
        }

        public ValueWriter(T value) : base(To.GetTypeWriter<T>(), value)
        {
        }
    }
    
    public class ValueWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.Value; } }

        internal readonly TypeWriter Type;

        private object _value;

        public object Value
        {
            get { return _value; }
            
            set
            {
                if (!(value is StatementWriter) && !Type.IsValidValue(value))
                {
                    throw new InvalidOperationException(string.Format(@"{0} is not a valid value type for type {1}", value.GetType(), Type.GetType().Name));
                }

                _value = value;
            }
        }

        public ValueWriter(TypeWriter type, object value = null)
        {
            Type = type;
            
            if (value != null)
            {
                Value = value;
            }
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.VariableType))
            {
                WriteType(builder, context);
                return;
            }
            
            if (context.Is(WriterContextFlags.Value))
            {
                WriteValue(builder, context);
                return;
            }

            base.Write(builder, context);
        }

        protected virtual void WriteValue(TokenBuilder builder, WriterContext context)
        {
            if (_value == null)
            {
                builder.Add(Token.Null);
            }
            else if (_value is StatementWriter)
            {
                (_value as Writer).Write(builder, context.Switch(WriterContextFlags.Statement));
            }
            else if (_value is Writer)
            {
                (_value as Writer).Write(builder, context);
            }
            else if (_value is string)
            {
                builder.Literal(_value as string);
            }
            else if (_value is char)
            {
                builder.Literal((char)_value);
            }
            else if (_value is bool)
            {
                builder.Add((bool)_value ? Token.True : Token.False);
            }
            else if (_value is Enum)
            {
                builder.Add(_value.GetType().Name);
                builder.Add(Token.Dot);
                builder.Add(_value.ToString());
            }
            else if (_value != null)
            {
                builder.Add(_value.ToString());
            }
        }

        protected virtual void WriteType(TokenBuilder builder, WriterContext context)
        {
            Type.Write(builder, context);
        }

        internal virtual bool IsEquivalentTo<T>(T value) where T : ValueWriter
        {
            return value != null && Type.IsEquivalentTo(value.Type);
        }
    }
}