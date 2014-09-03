using Coding;

namespace CSharp.Writers
{
	public interface IWriter
	{
		void Build(TokenBuilder builder);
	}
}