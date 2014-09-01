using System;

namespace Definition.Validation.Number
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class DecimalValidator : ValidatorAttribute
	{
		internal DecimalValidator()
		{
		}

		internal DecimalValidator(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal DecimalValidator(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}