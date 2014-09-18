using System;
using Coding.Builder;

namespace Coding.Writers
{
    public class EnumValueTypeWriter<T> : TypeWriter where T : struct, IConvertible 
    {
        public EnumValueTypeWriter()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
        }
        
        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(typeof(T).Name);
        }

        protected internal override bool IsValidType(Type type)
        {
            return type == typeof(T);
        }
    }
}