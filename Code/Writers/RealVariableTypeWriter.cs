using System;

using Coding.Builder;

namespace Coding.Writers
{
    public class RealVariableTypeWriter<TType> : VariableTypeWriter
    {
        internal readonly Type Type;
        
        public RealVariableTypeWriter()
        {
            Type = typeof(TType);

            if (Type.IsPrimitive || Type == typeof(string) || Type == typeof(object))
            {
                throw new InvalidOperationException(string.Format("RealVariableTypeWriter cannot be used to wrap WellKnownVariableType {0}. Use the {0}Writer instead.", Type.Name));
            }
        }
        
        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(typeof(TType).Name);
        }
    }
}
