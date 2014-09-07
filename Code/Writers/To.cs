using System;

using Coding.Tokens;

namespace Coding.Writers
{
    internal static class To
    {
        public static Token Token(PrimaryAccessModifiers modifier)
        {
            switch (modifier)
            {
                case PrimaryAccessModifiers.Public:
                    return Tokens.Token.Public;
                case PrimaryAccessModifiers.Private:
                    return Tokens.Token.Private;
                case PrimaryAccessModifiers.Protected:
                    return Tokens.Token.Protected;
                case PrimaryAccessModifiers.Internal:
                    return Tokens.Token.Internal;
                default:
                    throw new ArgumentOutOfRangeException("modifier");
            }
        }

        public static Token Token(SecondaryAccessModifiers? modifier)
        {
            switch (modifier)
            {
                case SecondaryAccessModifiers.Abstract:
                    return Tokens.Token.Abstract;
                case SecondaryAccessModifiers.Readonly:
                    return Tokens.Token.Readonly;
                case SecondaryAccessModifiers.Static:
                    return Tokens.Token.Static;
                case SecondaryAccessModifiers.StaticReadonly:
                    return Tokens.Token.StaticReadonly;
                case SecondaryAccessModifiers.Virtual:
                    return Tokens.Token.Virtual;
                case SecondaryAccessModifiers.Override:
                    return Tokens.Token.Override;
                case null:
                    return Tokens.Token.Empty;
                default:
                    throw new ArgumentOutOfRangeException("modifier");
            }
        }

        public static Token TokenConditional(bool condition, PrimaryAccessModifiers modifier)
        {
            return condition ? Token(modifier) : Tokens.Token.Empty;
        }
    }
}
