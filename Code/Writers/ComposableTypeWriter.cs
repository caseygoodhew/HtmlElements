using System;
using System.Collections.Generic;

using Coding.Builder;

namespace Coding.Writers
{
    // external type composition
    public class ComposableTypeWriter : InvokableContainerWriter
    {
        internal readonly Type Type;
        
        public ComposableTypeWriter(Type type)
        {
            if (!type.IsComposable())
            {
                throw new InvalidOperationException(string.Format("Type {0} is not a class, interface or struct.", type.Name));
            }
            
            if (typeof(Writer).IsAssignableFrom(type))
            {
                throw new InvalidOperationException("ComposableTypeWriter cannot be used to wrap other Writers.");
            }
            
            Type = type;
        }
        
        protected override void WriteTypeName(TokenBuilder builder, WriterContext context)
        {
            builder.Add(Type.Name);
        }

        protected internal override bool IsValidValue(object value, bool asParameterDefault = false)
        {
            return value == null || (!asParameterDefault && Type.IsInstanceOfType(value));
        }

        internal override List<MethodWriter> GetMethods(MethodWriter method)
        {
            throw new NotImplementedException();
        }

        internal override List<MethodWriter> GetMethods(string name)
        {
            throw new NotImplementedException();
        }
    }
}