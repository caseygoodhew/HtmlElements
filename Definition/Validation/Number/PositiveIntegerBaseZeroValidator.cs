using System;

namespace Definition.Validation.Number
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class PositiveIntegerBaseZeroValidator : NumberValidatorAttribute<int>
	{
		private static readonly int? minimum = 0;

		private static readonly int? maximum = null;

		internal PositiveIntegerBaseZeroValidator() : base(minimum, maximum)
		{
		}

		internal PositiveIntegerBaseZeroValidator(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(minimum, maximum, requiredAttributeType, requiredAttributeValue)
		{
		}

		internal PositiveIntegerBaseZeroValidator(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(minimum, maximum, whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}