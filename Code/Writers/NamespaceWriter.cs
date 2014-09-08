using System.Collections.Generic;

using Coding.Builder;
using Coding.Tokens;

namespace Coding.Writers
{
    public class NamespaceWriter : Writer
    {
        protected override WriterContextFlags DefaultContextFlag { get { return WriterContextFlags.NamespaceDeclaration; } }
        
        internal readonly string Name;

        internal readonly NamespaceWriter ParentNamespace;

        internal readonly List<EnumWriter> Enums;

        internal readonly List<InterfaceWriter> Interfaces;

        internal readonly List<StructWriter> Structs;
        
        internal readonly List<ClassWriter> Classes;

        public NamespaceWriter(NamespaceWriter parentNamespace, string name) : this(name)
        {
            ParentNamespace = parentNamespace;
        }

        public NamespaceWriter(string name)
        {
            Name = name;
            Enums = new List<EnumWriter>();
            Interfaces = new List<InterfaceWriter>();
            Structs = new List<StructWriter>();
            Classes = new List<ClassWriter>();
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            if (context.Is(WriterContextFlags.NamespaceDeclaration) || context.Is(WriterContextFlags.ModuleDeclaration))
            {
                WriteNamespaceDeclaration(builder, context);
                return;
            }

            if (context.Is(WriterContextFlags.NamespaceName))
            {
                WriteNamespaceName(builder, context);
                return;
            }

            base.Write(builder, context);
        }

        private void WriteNamespaceDeclaration(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Token.Namespace);
            
            WriteNamespaceName(builder, context);

            builder.Add(Token.OpenCurly);

            builder.Join(Enums, x => x.Write(builder, context.Switch(WriterContextFlags.EnumDeclaration)), Token.NewLine);

            builder.Join(Interfaces, x => x.Write(builder, context.Switch(WriterContextFlags.InterfaceDeclaration)), Token.NewLine);

            builder.Join(Structs, x => x.Write(builder, context.Switch(WriterContextFlags.StructDeclaration)), Token.NewLine);

            builder.Join(Classes, x => x.Write(builder, context.Switch(WriterContextFlags.ClassDeclaration)), Token.NewLine);

            builder.Add(Token.CloseCurly);
        }

        private void WriteNamespaceName(TokenBuilder builder, WriterContext context)
        {
            if (ParentNamespace != null)
            {
                ParentNamespace.Write(builder, context.Switch(WriterContextFlags.NamespaceName));
                builder.Add(Token.Dot);
            }
            
            builder.Add(Name);
        }
    }
}
