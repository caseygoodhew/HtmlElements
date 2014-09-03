using Coding;

namespace CSharp
{
	public class UsingWriter : Writer, IModuleChild
	{
		internal NamespaceWriter Namespace { get; set; }

		public UsingWriter(string @namespace)
		{
			Namespace = new NamespaceWriter(@namespace);
		}

		public UsingWriter(NamespaceWriter @namespace)
		{
			Namespace = @namespace;
		}

		/*public override Code GetCode()
		{
			return new CodeLine().Add("using").Add(Namespace.Name).SemiColon();
		}*/

		public override void Build(TokenBuilder builder)
		{
			builder.Add(Tokens.Using).Add(Namespace.Name).Add(Tokens.SemiColon);
		}
	}
}