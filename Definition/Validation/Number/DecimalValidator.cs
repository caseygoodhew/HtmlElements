using System;

namespace Definition.Validation.Number
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class DecimalValidator : NumberValidatorAttribute<decimal>
	{
		private static readonly decimal? minimum = null;

		private static readonly decimal? maximum = null;

		internal DecimalValidator() : base(minimum, maximum)
		{
		}

		internal DecimalValidator(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(minimum, maximum, requiredAttributeType, requiredAttributeValue)
		{
		}

		internal DecimalValidator(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(minimum, maximum, whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}