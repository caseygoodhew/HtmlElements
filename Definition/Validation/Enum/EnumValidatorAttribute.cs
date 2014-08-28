using System;

namespace Definition.Validation.Enum
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal abstract class EnumValidatorAttribute : ValidatorAttribute
    {
        internal abstract Type EnumType { get; }
        
        protected EnumValidatorAttribute()
        {
        }

        protected EnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
            : base(requiredAttributeType, requiredAttributeValue)
        {
        }

        protected EnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
            : base(whenValueIs, requiredAttributeType, requiredAttributeValue)
        {
        }
    }
}