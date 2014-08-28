using System;

namespace Definition.Validation.NotImplemented
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class HtmlValidatorAttribute : NotImplementedValidatorAttribute
	{
		internal HtmlValidatorAttribute()
		{
		}

		internal HtmlValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal HtmlValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}