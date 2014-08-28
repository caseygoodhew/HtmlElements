using Template.Validation;

namespace Template.Attributes
{
    public abstract class Attribute
    {
        public readonly string AttributeName;
        
        protected Attribute(string attributeName)
        {
            AttributeName = attributeName;
        }

        protected TValidator GetValidator<TValidator>() where TValidator : Validator, new()
        {
            // TODO: this will use caching to minimize reflection impact
            return new TValidator();
        }

        public abstract Validator GetValidator();

        public virtual string GetName()
        {
            return AttributeName;
        }
    }
}