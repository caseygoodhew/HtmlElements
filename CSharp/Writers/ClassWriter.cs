using Coding;

namespace CSharp.Writers
{
    public class ClassWriter : WriterWithChildren<IClassChild>, INamespaceChild, IParameterTypeWriter
    {
        internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

        internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; }

        public string Name { get; internal set; }

        internal GenericDeclarationWriter GenericDeclaration { get; set; }

        public ClassWriter(string name)
        {
            Name = name;
            PrimaryAccessModifier = PrimaryAccessModifiers.Public;
            SecondaryAccessModifier = null;
        }
        
        public override void Build(TokenBuilder builder)
        {
            builder
                .Add(To.Token(PrimaryAccessModifier))
                .Add(To.Token(SecondaryAccessModifier))
                .Add(Token.Class)
                .Add(Name);

            if (GenericDeclaration != null)
            {
                GenericDeclaration.Build(builder);
                GenericDeclaration.BuildConstraints(builder);
            }

            builder.Add(Token.OpenCurly);

            foreach (var child in SortChildren<PropertyWriter>())
            {
                child.Build(builder);
            }

            builder.Add(Token.CloseCurly);
        }

        public void BuildParameterTypeName(TokenBuilder builder)
        {
            builder.Add(Name);
        }
    }
}