
using Definition.Attributes;

namespace Definition.Other
{
    public abstract class ElementAttributeInstance<TElementAttribute> where TElementAttribute : AttributeDefinition
    {
        public readonly TElementAttribute ElementAttribute;

        protected ElementAttributeInstance(TElementAttribute elementAttribute)
        {
            ElementAttribute = elementAttribute;
        }
    }
}
