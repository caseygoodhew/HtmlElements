using System;

using Definition.Enums;

namespace Definition.Validation.Enum
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class TrackKindEnumValidatorAttribute : EnumValidatorAttribute
	{
        internal override Type EnumType
        {
            get { return Enum.EnumType.Get<TrackKind>(); }
        }

        internal TrackKindEnumValidatorAttribute()
		{
		}

		internal TrackKindEnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
		}

		internal TrackKindEnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
		}
	}
}