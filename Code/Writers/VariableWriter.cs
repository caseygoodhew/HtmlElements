using System;
using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public abstract class ValueWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.Value; } }

        internal readonly TypeWriter Type;

        private object value;

        internal object Value
        {
            get { return value; }
            
            set
            {
                if (!Type.IsValidType(value.GetType()))
                {
                    throw new InvalidOperationException(string.Format(@"{0} is not a valid value for type {1}", value, Type.GetType().Name));
                }

                this.value = value;
            }
        }

        protected ValueWriter(TypeWriter type, object value = null)
        {
            Type = type;
            
            if (value != null)
            {
                Value = value;
            }
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.Value))
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
            if (value is Writer)
            {
                (value as Writer).Write(builder, context);
            }
            else if (value is string)
            {
                builder.Add(Token.DoubleQuote);
                builder.Add(value.ToString());
                builder.Add(Token.DoubleQuote);
            }
            else if (value is char)
            {
                builder.Add(Token.SingleQuote);
                builder.Add(value.ToString());
                builder.Add(Token.SingleQuote);
            }
            else
            {
                builder.Add(value.ToString());
            }
        }

        protected virtual void WriteType(TokenBuilder builder, WriterContext context)
        {
            Type.Write(builder, context);
        }
    }

    public class VariableWriter<T> : VariableWriter
    {
        public VariableWriter(string name, object value = null) : base(TypeWriter.Get<T>(), name, value)
        {
        }
    }
    
    public class VariableWriter : ValueWriter
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.VariableDeclaration; } }
        
        internal readonly string Name;

        public VariableWriter(TypeWriter type, string name, object value = null) : base(type, value)
        {
            Name = name;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.VariableDeclaration) || 
                context.Is(WriterContextFlags.ClassDeclaration) ||
                context.Is(WriterContextFlags.InterfaceDeclaration) || 
                context.Is(WriterContextFlags.StructDeclaration))
            {
                WriteVariableDeclaration(builder, context);
                return;
            }

            if (context.Is(WriterContextFlags.VariableType))
            {
                WriteType(builder, context);
                return;
            }

            if (context.Is(WriterContextFlags.VariableName))
            {
                WriteVariableName(builder, context);
                return;
            }
            
            base.Write(builder, context);
        }

        private void WriteVariableDeclaration(TokenBuilder builder, WriterContext context)
        {
            WriteAccessModifier(builder, context);

            WriteType(builder, context.Switch(WriterContextFlags.VariableType));

            WriteVariableName(builder, context);

            WriteDeclarationCompletion(builder, context);
        }

        protected virtual void WriteAccessModifier(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }

        protected virtual void WriteVariableName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Name);
        }
        
        protected virtual void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.TerminatingSemiColon);
        }
    }
}
