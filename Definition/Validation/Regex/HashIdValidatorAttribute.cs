using System;

namespace Definition.Validation.Regex
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class HashIdValidatorAttribute : RegexValidatorAttribute
	{
		private static readonly string regex = "^[#][A-Za-z][-A-Za-z0-9_:.]*$";

		internal HashIdValidatorAttribute()
			: base(regex)
		{
		}

		internal HashIdValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(regex, requiredAttributeType, requiredAttributeValue)
		{
		}

		internal HashIdValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(regex, whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}