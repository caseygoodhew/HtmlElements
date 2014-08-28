using System.Collections.Generic;
using Template.Attributes;

namespace Template.Elements
{
    public static class Reveal
    {
        public static void AddAttribute(Element element, AttributeInstance attributeInstance)
        {
            element.AddAttributeInstance(attributeInstance);
        }

        public static IEnumerable<AttributeInstance> GetAttributeInstances(Element element, string name)
        {
            return element.GetAttributeInstances(name);
        }

        public static void Validate(Element element)
        {
            element.Validate();
        }
    }
}