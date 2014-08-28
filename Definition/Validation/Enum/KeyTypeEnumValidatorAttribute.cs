using System;

using Definition.Enums;

namespace Definition.Validation.Enum
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class KeyTypeEnumValidatorAttribute : EnumValidatorAttribute
    {
        internal override Type EnumType
        {
            get { return Enum.EnumType.Get<KeyType>(); }
        }

        internal KeyTypeEnumValidatorAttribute()
        {
        }

        internal KeyTypeEnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
            : base(requiredAttributeType, requiredAttributeValue)
        {
        }

        internal KeyTypeEnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
            : base(whenValueIs, requiredAttributeType, requiredAttributeValue)
        {
        }
    }
}