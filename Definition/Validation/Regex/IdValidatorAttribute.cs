using System;

namespace Definition.Validation.Regex
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class IdValidatorAttribute : RegexValidatorAttribute
    {
        protected static readonly string baseRegex = "[A-Za-z][-A-Za-z0-9_:.]*";

        private static readonly string regex = "^"+baseRegex+"$";

        internal IdValidatorAttribute()
            : base(regex)
        {
        }

        internal IdValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
            : base(regex, requiredAttributeType, requiredAttributeValue)
        {
        }

        internal IdValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
            : base(regex, whenValueIs, requiredAttributeType, requiredAttributeValue)
        {
        }

        protected IdValidatorAttribute(string overrideRegex)
            : base(overrideRegex)
        {
        }

        protected IdValidatorAttribute(string overrideRegex, Type requiredAttributeType, object requiredAttributeValue = null)
            : base(overrideRegex, requiredAttributeType, requiredAttributeValue)
        {
        }

        protected IdValidatorAttribute(string overrideRegex, object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
            : base(overrideRegex, whenValueIs, requiredAttributeType, requiredAttributeValue)
        {
        }
    }
}