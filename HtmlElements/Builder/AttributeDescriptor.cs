using System;

namespace HtmlElements.Builder
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