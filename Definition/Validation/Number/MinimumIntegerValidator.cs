using System;

namespace Definition.Validation.Number
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	internal abstract class MinimumIntegerValidator : ValidatorAttribute
	{
		internal readonly int Minimum;

		internal MinimumIntegerValidator(int minimum)
		{
			Minimum = minimum;
		}

		internal MinimumIntegerValidator(int minimum, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
			Minimum = minimum;
		}

		internal MinimumIntegerValidator(int minimum, object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
			Minimum = minimum;
		}
	}
}