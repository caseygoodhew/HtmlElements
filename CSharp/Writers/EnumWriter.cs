using Coding;

namespace CSharp.Writers
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
			builder.Add(To.Token(PrimaryAccessModifier)).Add(Token.Enum).Add(Name);
			
			builder.Add(Token.OpenCurly);

			builder.Join(Children, x => x.Build(builder), Token.TerminatingComma);

			builder.Add(Token.CloseCurly);
		}
	}
}