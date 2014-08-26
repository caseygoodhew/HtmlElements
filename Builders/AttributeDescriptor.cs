using System;

namespace Builders
{
    public class AttributeDescriptor
    {
        public readonly Type Type;

        internal AttributeDescriptor(Type type)
        {
            Type = type;
        }
    }
}