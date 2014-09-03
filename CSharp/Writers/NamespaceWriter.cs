using Coding;

namespace CSharp.Writers
{
	public class NamespaceWriter : WriterWithChildren<INamespaceChild>, IModuleChild
	{
		internal string Name { get; set; }

		public NamespaceWriter(string name)
		{
			Name = name;
		}

		public override void Build(TokenBuilder builder)
		{
			builder.Add(Token.Namespace).Add(Name);
			builder.Add(Token.OpenCurly);

			foreach (var child in SortChildren<EnumWriter, InterfaceWriter, ClassWriter>())
			{
				child.Build(builder);
			}

			builder.Add(Token.CloseCurly);
		}
	}
}