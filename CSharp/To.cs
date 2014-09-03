using System;
using System.Collections;
using Coding;

namespace CSharp
{
	internal static class To
	{
		public static Tokens Token(PrimaryAccessModifiers modifier)
		{
			switch (modifier)
			{
				case PrimaryAccessModifiers.Public:
					return Tokens.Public;
				case PrimaryAccessModifiers.Private:
					return Tokens.Private;
				case PrimaryAccessModifiers.Protected:
					return Tokens.Protected;
				case PrimaryAccessModifiers.Internal:
					return Tokens.Internal;
				default:
					throw new ArgumentOutOfRangeException("modifier");
			}
		}

		public static Tokens Token(SecondaryAccessModifiers? modifier)
		{
			switch (modifier)
			{
				case SecondaryAccessModifiers.Abstract:
					return Tokens.Abstract;
				case SecondaryAccessModifiers.Readonly:
					return Tokens.Readonly;
				case SecondaryAccessModifiers.Static:
					return Tokens.Static;
				case SecondaryAccessModifiers.StaticReadonly:
					return Tokens.StaticReadonly;
				case null:
					return Tokens.Empty;
				default:
					throw new ArgumentOutOfRangeException("modifier");
			}
		}
	}
}
