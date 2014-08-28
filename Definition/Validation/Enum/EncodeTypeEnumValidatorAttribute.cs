using System;

namespace Definition.Validation.Enum
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class EncodeTypeEnumValidatorAttribute : EnumValidatorAttribute<EncodeType>
	{
		internal EncodeTypeEnumValidatorAttribute()
		{
		}

		internal EncodeTypeEnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal EncodeTypeEnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}