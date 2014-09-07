using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ClassWriter : InterfaceWriter
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.ClassDeclaration; } }
        
        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; } 

        internal ExtendsClassWriter ExtendsClass { get; set; }
        
        public ClassWriter(string name) : base(name, Token.Class)
        {
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.NamespaceDeclaration) || context.Is(WriterContextFlags.ClassDeclaration))
            {
                WriteDeclaration(builder, context.Switch(WriterContextFlags.ClassDeclaration));
                return;
            }
            
            base.Write(builder, context);
        }

        protected override void WriteAccessModifier(TokenBuilder builder, WriterContext context)
        {
            base.WriteAccessModifier(builder, context);
            builder.Add(To.Token(SecondaryAccessModifier));
        }

        protected override void WriteInheritance(TokenBuilder builder, WriterContext context)
        {
            if (ExtendsClass == null)
            {
                WriteImplementsInterfaces(builder, context);
            }
            else
            {
                ExtendsClass.Write(builder, context.Switch(WriterContextFlags.ExtendsClass));
                WriteImplementsInterfaces(builder, context, Token.Comma);
            }
        }
    }
}
