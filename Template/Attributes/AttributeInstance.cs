using Template.Elements;
using Template.Validation;

namespace Template.Attributes
{
    public abstract class AttributeInstance
    {
        protected readonly Attribute Attribute;

        protected AttributeInstance(Attribute attribute)
        {
            Attribute = attribute;
        }
        
        public string Validate(Element element)
        {
            return Validate(element, Attribute.GetValidator());
        }

        protected abstract string Validate(Element element, Validator validator);

        public string GetName()
        {
            return Attribute.GetName();
        }
        
        public abstract string GetValue();
    }
}