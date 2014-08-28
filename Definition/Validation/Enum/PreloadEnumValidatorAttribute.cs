using System;

using Definition.Enums;

namespace Definition.Validation.Enum
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class PreloadEnumValidatorAttribute : EnumValidatorAttribute
    {
        internal override Type EnumType
        {
            get { return Enum.EnumType.Get<Preload>(); }
        }

        internal PreloadEnumValidatorAttribute()
        {
        }

        internal PreloadEnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
            : base(requiredAttributeType, requiredAttributeValue)
        {
        }

        internal PreloadEnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
            : base(whenValueIs, requiredAttributeType, requiredAttributeValue)
        {
        }
    }
}