using System;
using Coding;

namespace CSharp.Writers
{
    public class TypeParameterWriter<T> : Writer, IParameterTypeWriter
    {
        internal override WriterContext DefaultWriterContext { get { return WriterContext.ParameterDeclaration; } }
        
        public string Name
        {
            get { return ResolveTypeName(typeof(T)); }
        }

        public override void Write(TokenBuilder builder, WriterContext context)
        {
            switch (context)
            {
                case WriterContext.ParameterDeclaration:
                    builder.Add(Name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("context");
            }
        }

        private static string ResolveTypeName(Type type)
        {
            string result = string.Empty;
            
            if (type.IsValueType)
            {
                result = ResolveValueTypeName(type);
            }

            if (string.IsNullOrEmpty(result))
            {
                result = ResolveReferenceTypename(type);
            }
                        
            return string.IsNullOrEmpty(result) ? type.Name : result;
        }

        private static string ResolveReferenceTypename(Type type)
        {
            if (type == typeof(object))
            {
                return "object";
            }

            if (type == typeof(string))
            {
                return "string";
            }

            return null;
        }

        private static string ResolveValueTypeName(Type type)
        {
            if (!type.IsValueType)
            {
                throw new ArgumentException();
            }

            if (type == typeof(bool))
            {
                return "bool";
            }

            if (type == typeof(byte))
            {
                return "byte";
            }

            if (type == typeof(char))
            {
                return "char";
            }

            if (type == typeof(decimal))
            {
                return "decimal";
            }

            if (type == typeof(double))
            {
                return "double";
            }

            if (type == typeof(float))
            {
                return "float";
            }

            if (type == typeof(int))
            {
                return "int";
            }

            if (type == typeof(long))
            {
                return "long";
            }

            if (type == typeof(sbyte))
            {
                return "sbyte";
            }

            if (type == typeof(short))
            {
                return "short";
            }

            if (type == typeof(uint))
            {
                return "uint";
            }

            if (type == typeof(ulong))
            {
                return "ulong";
            }

            if (type == typeof(ushort))
            {
                return "ushort";
            }

            return null;
        }
    }
}