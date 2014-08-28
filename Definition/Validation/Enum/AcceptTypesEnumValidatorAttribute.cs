using System;

namespace Definition.Validation.Enum
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class AcceptTypesEnumValidatorAttribute : EnumValidatorAttribute<AcceptTypes>
	{
		internal AcceptTypesEnumValidatorAttribute()
		{
		}

		internal AcceptTypesEnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal AcceptTypesEnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}