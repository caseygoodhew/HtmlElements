﻿using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class VariableWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.VariableDeclaration; } }
        
        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; }

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
            if (context.Is(WriterContextFlags.VariableDeclaration) || context.Is(WriterContextFlags.ClassDeclaration))
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
            builder.Add(To.Token(PrimaryAccessModifier));
        }

        protected virtual void WriteSecondaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            builder.Add(To.Token(SecondaryAccessModifier));
        }

        protected virtual void WriteDeclarationCompletion(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.TerminatingSemiColon);
        }
    }
}