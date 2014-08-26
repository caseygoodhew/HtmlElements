namespace TheGoal.Programmed
{
    public abstract class AttributeInstance
    {
        protected readonly ElementAttribute ElementAttribute;

        protected AttributeInstance(ElementAttribute elementAttribute)
        {
            ElementAttribute = elementAttribute;
        }
        
        public string Validate(Element element)
        {
            return Validate(element, ElementAttribute.GetValidator());
        }

        protected abstract string Validate(Element element, AttributeValidator attributeValidator);

        public string GetName()
        {
            return ElementAttribute.GetName();
        }
        
        public abstract string GetValue();
    }
}