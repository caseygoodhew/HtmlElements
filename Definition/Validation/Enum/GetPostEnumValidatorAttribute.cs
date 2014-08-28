using System;

namespace Definition.Validation.Enum
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class GetPostEnumValidatorAttribute : EnumValidatorAttribute<GetPost>
	{
		internal GetPostEnumValidatorAttribute()
		{
		}

		internal GetPostEnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal GetPostEnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}