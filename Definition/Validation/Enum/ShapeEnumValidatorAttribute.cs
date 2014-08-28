using System;

using Definition.Enums;

namespace Definition.Validation.Enum
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class ShapeEnumValidatorAttribute : EnumValidatorAttribute
    {
        internal override Type EnumType
        {
            get { return Enum.EnumType.Get<Shape>(); }
        }

        internal ShapeEnumValidatorAttribute()
        {
        }

        internal ShapeEnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
            : base(requiredAttributeType, requiredAttributeValue)
        {
        }

        internal ShapeEnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
            : base(whenValueIs, requiredAttributeType, requiredAttributeValue)
        {
        }
    }
}