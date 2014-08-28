using System;

namespace Definition.Validation.Number
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class PositiveIntegerBaseOneValidator : NumberValidatorAttribute<int>
	{
		private static readonly int? minimum = 1;

		private static readonly int? maximum = null;

		internal PositiveIntegerBaseOneValidator() : base(minimum, maximum)
		{
		}

		internal PositiveIntegerBaseOneValidator(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(minimum, maximum, requiredAttributeType, requiredAttributeValue)
		{
		}

		internal PositiveIntegerBaseOneValidator(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(minimum, maximum, whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}