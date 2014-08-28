using System;

using Definition.Enums;

namespace Definition.Validation.Enum
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class TextDirectionEnumValidatorAttribute : EnumValidatorAttribute
	{
        internal override Type EnumType
        {
            get { return Enum.EnumType.Get<TextDirection>(); }
        }
        
        internal TextDirectionEnumValidatorAttribute()
		{
		}

		internal TextDirectionEnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal TextDirectionEnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}