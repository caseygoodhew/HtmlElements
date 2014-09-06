using System;
using System.Linq;

namespace Coding.NewFolder1
{
    public class ClassWriter : InterfaceWriter
    {
        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; } 

        internal ExtendsClassWriter ExtendsClass { get; set; }
        
        public ClassWriter(string name) : base(name)
        {

        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.NamespaceDeclaration))
            {
                WriteClassDeclaration(builder, context.Switch(WriterContextFlags.ClassDeclaration));
                return;
            }
            
            base.Write(builder, context);
        }

        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Name);
        }

        private void WriteClassDeclaration(TokenBuilder builder, WriterContext context)
        {
            WritePrimaryAccessModifier(builder, context);
            WriteSecondaryAccessModifier(builder, context);

            builder.Add(Token.Class);

            builder.Add(Name);

            WriteGenericParameters(builder, context);

            if (ExtendsClass == null)
            {
                WriteImplementsInterfaces(builder, context);       
            }
            else
            {
                ExtendsClass.Write(builder, context.Switch(WriterContextFlags.ExtendsClass));
                WriteImplementsInterfaces(builder, context, Token.Comma);
            }

            WriteGenericConstraints(builder, context);

            WriteBody(builder, context);
        }

        protected virtual void WriteSecondaryAccessModifier(TokenBuilder builder, WriterContext context)
        {
            throw new NotImplementedException("uncomment");
            //builder.Add(To.Token(SeconaryAccessModifier));
        }
    }
}
