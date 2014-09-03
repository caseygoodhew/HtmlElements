using System.Linq;
using Coding;

namespace CSharp
{
	public class ModuleWriter : WriterWithChildren<IModuleChild>
	{
		public override void Build(TokenBuilder builder)
		{
			Children.OfType<UsingWriter>().ToList().ForEach(x => x.Build(builder));
			builder.Add(Tokens.EndSection);
			Children.OfType<NamespaceWriter>().ToList().ForEach(x => x.Build(builder));
		}
	}
}