
using Definition.Attributes;

namespace Definition.Other
{
    internal abstract class ElementAttributeInstance<TElementAttribute> where TElementAttribute : AttributeDefinition
    {
        internal readonly TElementAttribute ElementAttribute;

        protected ElementAttributeInstance(TElementAttribute elementAttribute)
        {
            ElementAttribute = elementAttribute;
        }
    }
}
