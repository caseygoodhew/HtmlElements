using System;

namespace Definition.Validation.Number
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	internal abstract class NumberValidatorAttribute<TNumber> : ValidatorAttribute where TNumber : struct, IComparable<TNumber>
	{
		internal readonly TNumber? Minimum;

		internal readonly TNumber? Maximum;

		internal NumberValidatorAttribute(TNumber? minimum, TNumber? maximum)
		{
			ValidateValues(minimum, maximum);
			Minimum = minimum;
			Maximum = maximum;
		}

		internal NumberValidatorAttribute(TNumber? minimum, TNumber? maximum, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
			ValidateValues(minimum, maximum);
			Minimum = minimum;
			Maximum = maximum;
		}

		internal NumberValidatorAttribute(TNumber? minimum, TNumber? maximum, object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
			ValidateValues(minimum, maximum);
			Minimum = minimum;
			Maximum = maximum;
		}

		private void ValidateValues(TNumber? minimum, TNumber? maximum)
		{
			if (minimum.HasValue && maximum.HasValue && minimum.Value.CompareTo(maximum.Value) > 0)
			{
				throw new ArgumentException(string.Format("The minimum value of {0} is greater than the maximum value of {1}.", minimum.Value, maximum.Value));
			}
		}
	}
}