using Coding;

namespace CSharp.Writers
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
			return new CodeLine().Add("using").Add(Namespace.XName).SemiColon();
		}*/

		public override void Build(TokenBuilder builder)
		{
			builder.Add(Token.Using).Add(Namespace.Name).Add(Token.SemiColon);
		}
	}
}