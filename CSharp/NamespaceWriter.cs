using Coding;

namespace CSharp
{
	public class NamespaceWriter : WriterWithChildren<INamespaceChild>, IModuleChild
	{
		internal string Name { get; set; }

		public NamespaceWriter(string name)
		{
			Name = name;
		}

		/*public override Code GetCode()
		{
			var declaration = new CodeLine().Add("namespace").Add(Name);
			var body = new CodeBlock()
				.Curlies()
				.Add(GetChildCodeBlocks<EnumWriter>())
				.Add(GetChildCodeBlocks<InterfaceWriter>())
				.Add(GetChildCodeBlocks<ClassWriter>());

			return new CodeBlock().Add(declaration).Add(body);
		}*/

		public override void Build(TokenBuilder builder)
		{
			builder.Add(Tokens.Namespace).Add(Name);
			builder.Add(Tokens.OpenCurly);

			foreach (var child in SortChildren<EnumWriter, InterfaceWriter, ClassWriter>())
			{
				child.Build(builder);
			}

			builder.Add(Tokens.CloseCurly);
		}
	}
}