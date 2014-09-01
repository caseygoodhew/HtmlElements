using System;

namespace Definition.Validation.Number
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class MimimumOneIntegerValidator : MinimumIntegerValidator
	{
		private const int MinimumValue = 1;
		
		internal MimimumOneIntegerValidator() : base(MinimumValue)
		{
		}

		internal MimimumOneIntegerValidator(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(MinimumValue, requiredAttributeType, requiredAttributeValue)
		{
		}

		internal MimimumOneIntegerValidator(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(MinimumValue, whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}