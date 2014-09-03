using System.Collections.Generic;
using System.Linq;
using Coding;

namespace CSharp
{
	public class ClassWriter : WriterWithChildren<IClassChild>, INamespaceChild, IParameterType
	{
		internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

		internal SecondaryAccessModifiers? SecondaryAccessModifier { get; set; }

		public string Name { get; set; }

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
				.Add(Tokens.Class)
				.Add(Name);

			if (GenericDeclaration != null)
			{
				GenericDeclaration.Build(builder);
				GenericDeclaration.BuildConstraints(builder);
			}

			builder
				.Add(Tokens.OpenCurly)
				.Add(Tokens.CloseCurly);
		}
	}
}