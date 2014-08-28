using System;

namespace Definition.Validation.Regex
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class IdValidatorAttribute : RegexValidatorAttribute
	{
		private static readonly string regex = "^[A-Za-z][-A-Za-z0-9_:.]*$";

		internal IdValidatorAttribute()
			: base(regex)
		{
		}

		internal IdValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(regex, requiredAttributeType, requiredAttributeValue)
		{
		}

		internal IdValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(regex, whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}