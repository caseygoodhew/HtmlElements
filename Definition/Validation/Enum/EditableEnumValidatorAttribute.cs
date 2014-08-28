using System;

namespace Definition.Validation.Enum
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class EditableEnumValidatorAttribute : EnumValidatorAttribute<Editable>
	{
		internal EditableEnumValidatorAttribute()
		{
		}

		internal EditableEnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal EditableEnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}