using System;

namespace Definition.Validation.Enum
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	internal abstract class EnumValidatorAttribute<TEnum> : ValidatorAttribute where TEnum : struct, IConvertible
	{
		internal readonly Type EnumType;
		
		protected EnumValidatorAttribute()
		{
			EnumType = GetEnumType();
		}

		protected EnumValidatorAttribute(Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
			EnumType = GetEnumType();
		}

		protected EnumValidatorAttribute(object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
			EnumType = GetEnumType();
		}

		private static Type GetEnumType()
		{
			var enumType = typeof(TEnum);

			if (!enumType.IsEnum)
			{
				throw new ArgumentException(string.Format("{0} is not an enum.", enumType.Name));
			}

			return enumType;
		}
	}
}