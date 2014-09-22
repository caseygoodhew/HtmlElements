using Coding.Builder;
using Coding.Tokens;
using Coding.Writers2;

namespace Coding.Writers
{
    public class VariableWriter<T> : VariableWriter
    {
        public VariableWriter(string name) : base(To.GetTypeWriter<T>(), name)
        {
        }
        
        public VariableWriter(string name, T value) : base(To.GetTypeWriter<T>(), name, value)
        {
        }

        public VariableWriter(string name, StatementWriter statement) : base(To.GetTypeWriter<T>(), name, statement)
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

            if (context.Is(WriterContextFlags.Value))
            {
                WriteValue(builder, context.Switch(WriterContextFlags.VariableName));
                return;
            }
            
            base.Write(builder, context);
        }

        private void WriteVariableDeclaration(TokenBuilder builder, WriterContext context)
        {
            WriteAccessModifier(builder, context);

            WriteType(builder, context.Switch(WriterContextFlags.VariableType));

            WriteVariableName(builder, context);

            WriteSetValue(builder, context);

            WriteDeclarationCompletion(builder, context);
        }

        protected virtual void WriteSetValue(TokenBuilder builder, WriterContext context)
        {
            if (Value == null)
            {
                return;
            }

            builder.Add(Token.Equals);
            WriteValue(builder, context);
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
