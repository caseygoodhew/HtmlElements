using System;

namespace Definition.Validation.Enum
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class LinkedRelEnumValidatorAttribute : EnumValidatorAttribute<LinkedRel>
	{
		internal LinkedRelEnumValidatorAttribute()
		{
		}

		internal LinkedRelEnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal LinkedRelEnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}