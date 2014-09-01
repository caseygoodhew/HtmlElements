using System;

namespace Definition.Validation.Number
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class IntegerValidator : ValidatorAttribute
	{
		internal IntegerValidator()
		{
		}

		internal IntegerValidator(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal IntegerValidator(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}