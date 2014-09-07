using System;

using Coding.Builder;

namespace Coding.Writers
{
    public class ImplementsGenericInterfaceWriter<TInterface> : ImplementsInterfaceWriter where TInterface : class
    {
        internal readonly Type InterfaceType;
        
        public ImplementsGenericInterfaceWriter()
        {
            InterfaceType = typeof(TInterface);

            if (!InterfaceType.IsInterface)
            {
                throw new InvalidOperationException(string.Format("{0} is not an interface.", InterfaceType.Name));
            }
        }
        
        protected override void WriteInterfaceType(TokenBuilder builder, WriterContext context)
        {
            builder.Add(InterfaceType.Name);
        }
    }
}