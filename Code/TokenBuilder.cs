using System;
using System.Collections.Generic;
using System.Linq;

namespace Coding
{
	public class TokenBuilder
	{
		private readonly List<Token> tokens = new List<Token>();

		public TokenBuilder Add(Token token)
		{
			tokens.Add(token);
			return this;
		}

		public TokenBuilder Add(string value)
		{
			tokens.Add(new WordToken(value));
			return this;
		}

		public TokenBuilder Add(Tokens token)
		{
			tokens.Add(TokenGenerator.GetPrefix(token));
			tokens.Add(TokenGenerator.Get(token));
			tokens.Add(TokenGenerator.GetPostfix(token));
			return this;
		}

		public TokenBuilder Join<T>(IEnumerable<T> items, Action<T> action, Tokens separator)
		{
			var itemList = items.ToList();
			for (var i = 0; i < itemList.Count; i++)
			{
				action.Invoke(itemList[i]);
				
				if (i + 1 < itemList.Count)
				{
					Add(separator);
				}
			}

			return this;
		}

		public override string ToString()
		{
			var context = new TokenContext(this);
			return string.Concat(GetTidied().Select(x => x.GetValue(context)));
		}

		private IEnumerable<Token> GetTidied()
		{
			return tokens
				.CleanEmptyTokens()
				.CleanExtraSpaces()
				.CleanRepeatingLineBreaks()
				.CleanCurlyLineBreaks()
				.AddIndentation();
		}
	}

	internal static class TidyExtensions
	{
		internal static List<Token> CleanEmptyTokens(this List<Token> source)
		{
			return source.Where(token => !token.Is<EmptyToken>()).ToList();
		}

		internal static List<Token> CleanExtraSpaces(this List<Token> source)
		{
			var result = new List<Token>();

			for (var i = 0; i < source.Count() - 1; i++)
			{
				var token = source[i];

				if (!token.Is<SpaceToken>())
				{
					result.Add(token);
					continue;
				}

				var nextToken = source[i + 1];

				if (!nextToken.Is<SpaceToken>())
				{
					result.Add(token);
				}
			}

			result.Add(source[source.Count - 1]);

			return result;
		}

		internal static List<Token> CleanRepeatingLineBreaks(this List<Token> source)
		{
			var result = new List<Token> { source[0] };

			for (var i = 1; i < source.Count() - 1; i++)
			{
				var token = source[i];
				
				if (!token.Is<NewLineToken>())
				{
					result.Add(token);
					continue;
				}

				var prevToken = source[i - 1];

				if (!prevToken.Is<NewLineToken>())
				{
					result.Add(token);
					continue;
				}
				
				var nextToken = source[i + 1];

				if (!nextToken.Is<NewLineToken>())
				{
					result.Add(token);
				}
			}

			result.Add(source[source.Count - 1]);

			return result;
		}

		internal static List<Token> CleanCurlyLineBreaks(this List<Token> source)
		{
			var result = new List<Token> { source[0] };

			for (var i = 1; i < source.Count() - 1; i++)
			{
				var token = source[i];
				
				if (token.Is<NewLineToken>())
				{
					var prevToken = source[i - 1];
					var nextToken = source[i + 1];

					if (prevToken.Is<NewLineToken>() && nextToken.Is<CloseCurlyToken>())
					{
						continue;
					}

					if (prevToken.Is<OpenCurlyToken>() && nextToken.Is<NewLineToken>())
					{
						continue;
					}
				}

				result.Add(token);
			}

			result.Add(source[source.Count - 1]);

			for (var i = result.Count - 2; i >= 0; i--)
			{
				var token = result[i];
				var nextToken = result[i+1];

				if (token.Is<OpenCurlyToken>() && nextToken.Is<CloseCurlyToken>())
				{
					result.Insert(i+1, new NewLineToken());
				}
			}

			return result;
		}
		
		internal static List<Token> AddIndentation(this List<Token> source)
		{
			var result = new List<Token>();
			var indent = 0;

			foreach (var token in source)
			{
				if (token.Is<EmptyToken>())
				{
					continue;
				}

				if (token.Is<CloseCurlyToken>())
				{
					var prevToken = result[result.Count - 1];
					if (prevToken.Is<TabToken>())
					{
						result.RemoveAt(result.Count - 1);
					}
					indent--;
				}

				result.Add(token);

				if (token.Is<NewLineToken>())
				{
					result.AddRange(Enumerable.Repeat(new TabToken(), indent));
				}

				if (token.Is<OpenCurlyToken>())
				{
					indent++;
				}
			}

			return result;
		}
	}
}