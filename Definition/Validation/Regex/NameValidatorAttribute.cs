using System;

namespace Definition.Validation.Regex
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class NameValidatorAttribute : IdValidatorAttribute
    {
        internal NameValidatorAttribute()
        {
        }

        internal NameValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
            : base(requiredAttributeType, requiredAttributeValue)
        {
        }

        internal NameValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
            : base(whenValueIs, requiredAttributeType, requiredAttributeValue)
        {
        }
    }
}