using System;

namespace Definition.Validation.Enum
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class OrderedListTypeEnumValidatorAttribute : EnumValidatorAttribute<OrderedListType>
	{
		internal OrderedListTypeEnumValidatorAttribute()
		{
		}

		internal OrderedListTypeEnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal OrderedListTypeEnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}