using System;

namespace Definition.Validation.Regex
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class ClassValidatorAttribute : RegexValidatorAttribute
	{
		private static readonly string regex = "^-?[_a-zA-Z]+[_a-zA-Z0-9-]*$";

		internal ClassValidatorAttribute()
			: base(regex)
		{
		}

		internal ClassValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(regex, requiredAttributeType, requiredAttributeValue)
		{
		}

		internal ClassValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(regex, whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}