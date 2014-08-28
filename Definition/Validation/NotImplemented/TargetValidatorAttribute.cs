using System;

namespace Definition.Validation.NotImplemented
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class TargetValidatorAttribute : NotImplementedValidatorAttribute
	{
		internal TargetValidatorAttribute()
		{
		}

		internal TargetValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal TargetValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}