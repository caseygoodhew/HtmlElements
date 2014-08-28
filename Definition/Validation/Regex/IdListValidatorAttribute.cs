using System;

namespace Definition.Validation.Regex
{
	[AttributeUsage(AttributeTargets.Class)]
    internal class IdListValidatorAttribute : IdValidatorAttribute
	{
	    private static readonly string regex = "^(" + baseRegex + @")+(\s*,\s*" + baseRegex + ")*$";

		internal IdListValidatorAttribute()
			: base(regex)
		{
		}

		internal IdListValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(regex, requiredAttributeType, requiredAttributeValue)
		{
		}

		internal IdListValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(regex, whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}