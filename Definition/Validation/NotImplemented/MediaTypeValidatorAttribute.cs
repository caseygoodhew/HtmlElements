using System;

namespace Definition.Validation.NotImplemented
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class MediaTypeValidatorAttribute : NotImplementedValidatorAttribute
	{
		internal MediaTypeValidatorAttribute()
		{
		}

		internal MediaTypeValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal MediaTypeValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}

    [AttributeUsage(AttributeTargets.Class)]
	internal class TextCssMediaTypeValidator : NotImplementedValidatorAttribute
	{
		internal TextCssMediaTypeValidator()
		{
		}

		internal TextCssMediaTypeValidator(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

        internal TextCssMediaTypeValidator(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}