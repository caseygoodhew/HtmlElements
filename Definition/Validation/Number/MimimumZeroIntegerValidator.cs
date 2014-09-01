using System;

namespace Definition.Validation.Number
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class MimimumZeroIntegerValidator : MinimumIntegerValidator
	{
		private const int MinimumValue = 0;
		
		internal MimimumZeroIntegerValidator() : base(MinimumValue)
		{
		}

		internal MimimumZeroIntegerValidator(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(MinimumValue, requiredAttributeType, requiredAttributeValue)
		{
		}

		internal MimimumZeroIntegerValidator(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(MinimumValue, whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}