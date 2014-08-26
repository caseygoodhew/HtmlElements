using TheGoal.Programmed;

namespace TheGoal.Generated
{
    public class ClassAttributeInstance : AttributeInstance
    {
        public readonly string Value;
        
        public ClassAttributeInstance(string value) : base(new ClassAttribute())
        {
            Value = value;
        }

        protected override string Validate(Element element, AttributeValidator attributeValidator)
        {
            return attributeValidator.Validate(element, Value);
        }

        public override string GetValue()
        {
            return Value;
        }
    }
}
