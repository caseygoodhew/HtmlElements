using System;

namespace Definition.Validation.Enum
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class ShapeEnumValidatorAttribute : EnumValidatorAttribute<Shape>
	{
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