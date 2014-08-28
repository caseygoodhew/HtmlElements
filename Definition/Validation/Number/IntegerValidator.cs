using System;

namespace Definition.Validation.Number
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class IntegerValidator : NumberValidatorAttribute<int>
	{
		private static readonly int? minimum = null;

		private static readonly int? maximum = null;

		internal IntegerValidator() : base(minimum, maximum)
		{
		}

		internal IntegerValidator(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(minimum, maximum, requiredAttributeType, requiredAttributeValue)
		{
		}

		internal IntegerValidator(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(minimum, maximum, whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}