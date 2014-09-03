using System;

using Coding;

namespace CSharp
{
    internal static class To
    {
        public static Token Token(PrimaryAccessModifiers modifier)
        {
            switch (modifier)
            {
                case PrimaryAccessModifiers.Public:
                    return Coding.Token.Public;
                case PrimaryAccessModifiers.Private:
                    return Coding.Token.Private;
                case PrimaryAccessModifiers.Protected:
                    return Coding.Token.Protected;
                case PrimaryAccessModifiers.Internal:
                    return Coding.Token.Internal;
                default:
                    throw new ArgumentOutOfRangeException("modifier");
            }
        }

        public static Token Token(SecondaryAccessModifiers? modifier)
        {
            switch (modifier)
            {
                case SecondaryAccessModifiers.Abstract:
                    return Coding.Token.Abstract;
                case SecondaryAccessModifiers.Readonly:
                    return Coding.Token.Readonly;
                case SecondaryAccessModifiers.Static:
                    return Coding.Token.Static;
                case SecondaryAccessModifiers.StaticReadonly:
                    return Coding.Token.StaticReadonly;
                case null:
                    return Coding.Token.Empty;
                default:
                    throw new ArgumentOutOfRangeException("modifier");
            }
        }

        public static Token TokenConditional(bool condition, PrimaryAccessModifiers modifier)
        {
            return condition ? Token(modifier) : Coding.Token.Empty;
        }
    }
}
