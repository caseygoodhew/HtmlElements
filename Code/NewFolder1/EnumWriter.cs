using System;
using System.Collections.Generic;
using System.Linq;

namespace Coding.NewFolder1
{
    public class EnumWriter : VariableTypeWriter
    {
        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        internal readonly string Name;

        internal readonly List<EnumValueWriter> EnumValues;

        public EnumWriter(string name, params EnumValueWriter[] enumValues)
        {
            Name = name;
            EnumValues = enumValues.ToList();
            PrimaryAccessModifier = PrimaryAccessModifiers.Public;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.EnumDeclaration))
            {
                WriteEnumDeclaration(builder, context);
                return;
            }
            
            base.Write(builder, context);
        }

        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Name);
        }

        private void WriteEnumDeclaration(TokenBuilder builder, WriterContext context)
        {
            WritePrimaryAccessModifier(builder, context);

            builder.Add(Token.Enum);

            WriteTypeName(builder, context);

            builder.Add(Token.OpenCurly);

            builder.Join(EnumValues, x => x.Write(builder, context), Token.Comma);
            
            builder.Add(Token.CloseCurly);
        }

        protected virtual void WritePrimaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            throw new NotImplementedException("uncomment");
            //builder.Add(To.Token(PrimaryAccessModifier));
        }
    }

    public class EnumValueWriter : Writer
    {
        internal readonly string Name;

        public EnumValueWriter(string name)
        {
            Name = name;
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Name);
        }
    }
}
