using System;
using System.Collections.Generic;
using System.Linq;

using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class EnumWriter : TypeWriter
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.EnumDeclaration; } }
        
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

        protected internal override bool IsValidType(Type type)
        {
            //return type == typeof(EnumValueWriter) && (value as EnumValueWriter).ParentEnum.Name == Name;
            throw new NotImplementedException();
        }

        private void WriteEnumDeclaration(TokenBuilder builder, WriterContext context)
        {
            WritePrimaryAccessModifier(builder, context);

            builder.Add(Token.Enum);

            WriteTypeName(builder, context);

            builder.Add(Token.OpenCurly);

            builder.Join(EnumValues, x => x.Write(builder, context), Token.TerminatingComma);
            
            builder.Add(Token.CloseCurly);
        }

        protected virtual void WritePrimaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            builder.Add(To.Token(PrimaryAccessModifier));
        }
    }
}
