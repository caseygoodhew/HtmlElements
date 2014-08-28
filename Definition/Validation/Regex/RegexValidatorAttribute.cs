using System;

namespace Definition.Validation.Regex
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	internal abstract class RegexValidatorAttribute : ValidatorAttribute
	{
		internal readonly string Regex;
		
		protected RegexValidatorAttribute(string regex)
		{
			Regex = regex;
		}

		protected RegexValidatorAttribute(string regex, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
			Regex = regex;
		}

		protected RegexValidatorAttribute(string regex, object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
			Regex = regex;
		}
	}
}