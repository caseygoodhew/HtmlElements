using System;

using Coding.Builder;

namespace Coding.Writers
{
    public class FieldWriter : VariableWriter
    {
        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; }
        
        public FieldWriter(VariableTypeWriter variableType, string name) : base(variableType, name)
        {
            PrimaryAccessModifier = PrimaryAccessModifiers.Public;
        }

        protected override void WriteAccessModifier(TokenBuilder builder, WriterContext context)
        {
            if (!context.Is(WriterContextFlags.VariableDeclaration) && 
                !context.Is(WriterContextFlags.ClassDeclaration) &&
                !context.Is(WriterContextFlags.StructDeclaration))
            {
                return;
            }

            
            builder.Add(To.Token(PrimaryAccessModifier));
            
            switch (SecondaryAccessModifier)
            {
                case null:
                case SecondaryAccessModifiers.Readonly:
                case SecondaryAccessModifiers.Static:
                case SecondaryAccessModifiers.StaticReadonly:
                    builder.Add(To.Token(SecondaryAccessModifier));
                    break;

                case SecondaryAccessModifiers.Abstract:
                case SecondaryAccessModifiers.Virtual:
                case SecondaryAccessModifiers.Override:
                    throw new InvalidOperationException(string.Format("Fields cannot be marked as {0}.", SecondaryAccessModifier.Value));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
