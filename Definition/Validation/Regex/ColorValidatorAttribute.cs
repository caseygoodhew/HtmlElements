using System;

namespace Definition.Validation.Regex
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class ColorValidatorAttribute : RegexValidatorAttribute
	{
        private static readonly string regex = "^#([A-Fa-f0-9]{6})$";

		internal ColorValidatorAttribute()
			: base(regex)
		{
		}

		internal ColorValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(regex, requiredAttributeType, requiredAttributeValue)
		{
		}

        internal ColorValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(regex, whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}