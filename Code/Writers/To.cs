using System;

using Coding.Tokens;

namespace Coding.Writers
{
    internal static class To
    {
        internal static Token Token(PrimaryAccessModifiers modifier)
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

        internal static Token Token(SecondaryAccessModifiers? modifier)
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

        internal static Token TokenConditional(bool condition, PrimaryAccessModifiers modifier)
        {
            return condition ? Token(modifier) : Tokens.Token.Empty;
        }

        internal static VariableTypeWriter VariableTypeWriter<TType>()
        {
            var ttype = typeof(TType);

            if (ttype.IsValueType)
            {
                if (ttype == typeof(bool))
                {
                    return new BoolWriter();
                }

                if (ttype == typeof(byte))
                {
                    return new ByteWriter();
                }

                if (ttype == typeof(char))
                {
                    return new CharWriter();
                }

                if (ttype == typeof(decimal))
                {
                    return new DecimalWriter();
                }

                if (ttype == typeof(double))
                {
                    return new DoubleWriter();
                }

                if (ttype == typeof(float))
                {
                    return new FloatWriter();
                }

                if (ttype == typeof(int))
                {
                    return new IntWriter();
                }

                if (ttype == typeof(long))
                {
                    return new LongWriter();
                }

                if (ttype == typeof(sbyte))
                {
                    return new SByteWriter();
                }

                if (ttype == typeof(short))
                {
                    return new ShortWriter();
                }

                if (ttype == typeof(uint))
                {
                    return new UIntWriter();
                }

                if (ttype == typeof(ulong))
                {
                    return new ULongWriter();
                }

                if (ttype == typeof(ushort))
                {
                    return new UShortWriter();
                }
            }

            if (ttype == typeof(string))
            {
                return new StringWriter();
            }

            if (ttype == typeof(object))
            {
                return new ObjectWriter();
            }

            if (typeof(VariableTypeWriter).IsAssignableFrom(ttype))
            {
                var constructor = ttype.GetConstructor(new Type[] { });
                
                if (constructor == null)
                {
                    throw new InvalidOperationException(string.Format("Cannot find a public parameterless constructor for VariableTypeWriter derived type {0}.", ttype.Name));
                }

                return constructor.Invoke(new object[] {}) as VariableTypeWriter;
            }

            return new RealVariableTypeWriter<TType>();
        }
    }
}
