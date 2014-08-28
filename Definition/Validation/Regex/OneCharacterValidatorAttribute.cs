using System;
using Definition.Validation.NotImplemented;

namespace Definition.Validation.Regex
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class OneCharacterValidatorAttribute : RegexValidatorAttribute
    {
        private static readonly string regex = "^.$";

        internal OneCharacterValidatorAttribute()
            : base(regex)
        {
        }

        internal OneCharacterValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
            : base(regex, requiredAttributeType, requiredAttributeValue)
        {
        }

        internal OneCharacterValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
            : base(regex, whenValueIs, requiredAttributeType, requiredAttributeValue)
        {
        }
    }
}