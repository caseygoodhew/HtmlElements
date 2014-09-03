using Coding;

namespace CSharp
{
	public abstract class Writer : IWriter
	{
		public string Write()
		{
			var builder = new TokenBuilder();
			Build(builder);
			return builder.ToString();
		}

		public abstract void Build(TokenBuilder builder);
	}
}