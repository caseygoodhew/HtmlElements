namespace TheGoal.Programmed
{
    public static class Reveal
    {
        public static void AddAttribute(Element element, AttributeInstance attributeInstance)
        {
            element.AddAttributeInstance(attributeInstance);
        }

        public static void Validate(Element element)
        {
            element.Validate();
        }
    }
}