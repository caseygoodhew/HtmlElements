using System;

using Coding.Tokens;

namespace Coding.Writers
{
    public static class To
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

        public static TypeWriter GetTypeWriter<TType>()
        {
            return GetTypeWriter(typeof(TType));
        }

        public static TypeWriter GetTypeWriter(Type type)
        {
            if (type.IsValueType)
            {
                if (type == typeof(bool))
                {
                    return new BoolWriter();
                }

                if (type == typeof(byte))
                {
                    return new ByteWriter();
                }

                if (type == typeof(char))
                {
                    return new CharWriter();
                }

                if (type == typeof(decimal))
                {
                    return new DecimalWriter();
                }

                if (type == typeof(double))
                {
                    return new DoubleWriter();
                }

                if (type == typeof(float))
                {
                    return new FloatWriter();
                }

                if (type == typeof(int))
                {
                    return new IntWriter();
                }

                if (type == typeof(long))
                {
                    return new LongWriter();
                }

                if (type == typeof(sbyte))
                {
                    return new SByteWriter();
                }

                if (type == typeof(short))
                {
                    return new ShortWriter();
                }

                if (type == typeof(uint))
                {
                    return new UIntWriter();
                }

                if (type == typeof(ulong))
                {
                    return new ULongWriter();
                }

                if (type == typeof(ushort))
                {
                    return new UShortWriter();
                }
            }

            if (type == typeof(string))
            {
                return new StringWriter();
            }

            if (type == typeof(object))
            {
                return new ObjectWriter();
            }

            if (typeof(TypeWriter).IsAssignableFrom(type))
            {
                var constructor = type.GetConstructor(new Type[] { });
                
                if (constructor == null)
                {
                    throw new InvalidOperationException(string.Format("Cannot find a public parameterless constructor for TypeWriter derived type {0}.", type.Name));
                }

                return constructor.Invoke(new object[] {}) as TypeWriter;
            }

            if (type.IsComposable())
            {
                return new ComposableTypeWriter(type);    
            }

            throw new ArgumentOutOfRangeException(string.Format("Could not find a corresponding TypeWriter for {0}.", type.Name));
        }

        internal static bool IsStruct(this Type type)
        {
            return type.IsValueType && !type.IsEnum && !type.IsPrimitive;
        }

        internal static bool IsComposable(this Type type)
        {
            return type.IsClass || type.IsInterface || type.IsStruct();
        }
    }
}
