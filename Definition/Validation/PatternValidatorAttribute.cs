using System;

namespace Definition.Validation
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class PatternValidatorAttribute : ValidatorAttribute
    {
        internal PatternValidatorAttribute()
        {
        }

        internal PatternValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
            : base(requiredAttributeType, requiredAttributeValue)
        {
        }

        internal PatternValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
            : base(whenValueIs, requiredAttributeType, requiredAttributeValue)
        {
        }
    }
}