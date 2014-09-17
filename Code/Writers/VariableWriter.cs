using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class VariableWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.VariableDeclaration; } }
        
        internal readonly VariableTypeWriter VariableType;
        
        internal readonly string Name;
        
        public VariableWriter(VariableTypeWriter variableType, string name)
        {
            VariableType = variableType;
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
                WriteVariableType(builder, context);
                return;
            }
            
            base.Write(builder, context);
        }

        private void WriteVariableDeclaration(TokenBuilder builder, WriterContext context)
        {
            WriteAccessModifier(builder, context);

            WriteVariableType(builder, context.Switch(WriterContextFlags.VariableType));
            
            builder.Add(Name);

            WriteDeclarationCompletion(builder, context);
        }

        protected virtual void WriteVariableType(TokenBuilder builder, WriterContext context)
        {
            VariableType.Write(builder, context);
        }

        protected virtual void WriteAccessModifier(TokenBuilder builder, WriterContext context)
        {
            // do nothing
        }
        
        protected virtual void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.TerminatingSemiColon);
        }
    }
}
