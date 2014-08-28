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
}