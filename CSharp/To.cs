using System;

using Coding;
using Coding.Tokens;
using Coding.Writers;

namespace CSharp
{
    internal static class To
    {
        public static Token Token(PrimaryAccessModifiers modifier)
        {
            switch (modifier)
            {
                case PrimaryAccessModifiers.Public:
                    return Coding.Tokens.Token.Public;
                case PrimaryAccessModifiers.Private:
                    return Coding.Tokens.Token.Private;
                case PrimaryAccessModifiers.Protected:
                    return Coding.Tokens.Token.Protected;
                case PrimaryAccessModifiers.Internal:
                    return Coding.Tokens.Token.Internal;
                default:
                    throw new ArgumentOutOfRangeException("modifier");
            }
        }

        public static Token Token(SecondaryAccessModifiers? modifier)
        {
            switch (modifier)
            {
                case SecondaryAccessModifiers.Abstract:
                    return Coding.Tokens.Token.Abstract;
                case SecondaryAccessModifiers.Readonly:
                    return Coding.Tokens.Token.Readonly;
                case SecondaryAccessModifiers.Static:
                    return Coding.Tokens.Token.Static;
                case SecondaryAccessModifiers.StaticReadonly:
                    return Coding.Tokens.Token.StaticReadonly;
                case SecondaryAccessModifiers.Virtual:
                    return Coding.Tokens.Token.Virtual;
                case SecondaryAccessModifiers.Override:
                    return Coding.Tokens.Token.Override;
                case null:
                    return Coding.Tokens.Token.Empty;
                default:
                    throw new ArgumentOutOfRangeException("modifier");
            }
        }

        public static Token TokenConditional(bool condition, PrimaryAccessModifiers modifier)
        {
            return condition ? Token(modifier) : Coding.Tokens.Token.Empty;
        }
    }
}
