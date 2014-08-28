using System;

namespace Definition.Validation.NotImplemented
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	internal abstract class NotImplementedValidatorAttribute : ValidatorAttribute
	{
		protected NotImplementedValidatorAttribute()
		{
		}

		protected NotImplementedValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		protected NotImplementedValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}