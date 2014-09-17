using System.Collections.Generic;
using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class ClassWriter : ComposableWriter
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.ClassDeclaration; } }
        
        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; } 

        internal ExtendsClassWriter ExtendsClass { get; set; }

        internal List<ConstructorWriter> Constructors { get; set; }
        
        public ClassWriter(string name) : base(name, Token.Class)
        {
            Constructors = new List<ConstructorWriter>();
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

        protected override void WriteMethods(TokenBuilder builder, WriterContext context)
        {
            builder.Join(Constructors, x => x.Write(builder, context), Token.NewLine);

            builder.Add(Token.NewLine);

            base.WriteMethods(builder, context);
        }
    }
}
