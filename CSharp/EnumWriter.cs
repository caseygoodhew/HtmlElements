using Coding;

namespace CSharp
{
	public class EnumWriter : WriterWithChildren<EnumValueWriter>, INamespaceChild
	{
		internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

		internal string Name { get; set; }

		public EnumWriter(string name)
		{
			Name = name;
			PrimaryAccessModifier = PrimaryAccessModifiers.Public;
		}

		public override void Build(TokenBuilder builder)
		{
			builder.Add(To.Token(PrimaryAccessModifier)).Add(Tokens.Enum).Add(Name);
			
			builder.Add(Tokens.OpenCurly);

			builder.Join(Children, x => x.Build(builder), Tokens.TerminatingComma);

			builder.Add(Tokens.CloseCurly);
		}
	}
}