using System;

namespace Coding
{
	internal class TokenContext
	{
		internal TokenBuilder Builder { get; private set; }

		internal int IndentLevel { get; private set; }

		public TokenContext(TokenBuilder builder)
		{
			Builder = builder;
		}

		internal void IndentMore()
		{
			IndentLevel ++;
		}

		internal void IndentLess()
		{
			IndentLevel--;

			if (IndentLevel < 0)
			{
				throw new InvalidOperationException();
			}
		}
	}
}
