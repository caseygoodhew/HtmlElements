namespace TheGoal.Programmed
{
    public abstract class ElementAttribute
    {
        public readonly string AttributeName;
        
        protected ElementAttribute(string attributeName)
        {
            AttributeName = attributeName;
        }

        protected TAttributeValidator GetValidator<TAttributeValidator>()
            where TAttributeValidator : AttributeValidator, new()
        {
            // TODO: this will use caching to minimize reflection impact
            return new TAttributeValidator();
        }

        public abstract AttributeValidator GetValidator();

        public virtual string GetName()
        {
            return AttributeName;
        }
    }
}