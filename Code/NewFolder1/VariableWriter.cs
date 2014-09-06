using System;

namespace Coding.NewFolder1
{
    public class VariableWriter : Writer
    {
        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        internal SecondaryAccessModifiers? SeconaryAccessModifier { get; set; }

        internal readonly VariableTypeWriter VariableType;
        
        internal readonly string Name;
        
        public VariableWriter(VariableTypeWriter variableType, string name)
        {
            PrimaryAccessModifier = PrimaryAccessModifiers.Public;
            VariableType = variableType;
            Name = name;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.VariableDeclaration))
            {
                WriteVariableDeclaration(builder, context);

                return;
            }

            if (context.Is(WriterContextFlags.VariableType))
            {
                VariableType.Write(builder, context);
                
                return;
            }
            
            base.Write(builder, context);
        }

        private void WriteVariableDeclaration(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.ClassDeclaration))
            {
                WritePrimaryAccessModifier(builder, context);
                WriteSecondaryAccessModifier(builder, context);
            }

            VariableType.Write(builder, context.Switch(WriterContextFlags.VariableType));
            
            builder.Add(Name);

            WriteDeclarationCompletion(builder, context);
        }
        
        protected virtual void WritePrimaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            throw new NotImplementedException("uncomment");
            //builder.Add(To.Token(PrimaryAccessModifier));
        }

        protected virtual void WriteSecondaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            throw new NotImplementedException("uncomment");
            //builder.Add(To.Token(SeconaryAccessModifier));
        }

        protected virtual void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.TerminatingSemiColon);
        }

        /*public T Clone<T>() where T : VariableWriter
        {
            return MemberwiseClone() as T;
        }*/
    }
}
