using System;

namespace Definition.Validation
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	internal class RequiresAttributeValidatorAttribute : ValidatorAttribute
	{
		internal RequiresAttributeValidatorAttribute()
		{
		}

		internal RequiresAttributeValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal RequiresAttributeValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}