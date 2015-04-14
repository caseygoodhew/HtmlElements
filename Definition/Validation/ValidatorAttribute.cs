using System;

namespace Definition.Validation
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	internal abstract class ValidatorAttribute : Attribute
	{
		internal readonly object WhenValueIs;
		
		internal readonly Type RequiredAttributeType;

		internal readonly object RequiredAttributeValue;

		protected ValidatorAttribute()
		{
		}

		protected ValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
		{
			RequiredAttributeType = requiredAttributeType;
			RequiredAttributeValue = requiredAttributeValue;
		}

		protected ValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: this(requiredAttributeType, requiredAttributeValue)
		{
			WhenValueIs = whenValueIs;
		}
	}
}