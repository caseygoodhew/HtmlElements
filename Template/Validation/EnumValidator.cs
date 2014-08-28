using System;
using Template.Elements;

namespace Template.Validation
{
	public class EnumValidator<TEnum> : Validator<TEnum> where TEnum : struct, IConvertible
	{
		public EnumValidator()
		{
			if (!typeof(TEnum).IsEnum)
			{
				throw new ArgumentException("TEnum must be an enumerated type");
			}
		}

		public override string Validate(Element el, TEnum param)
		{
			return Enum.IsDefined(typeof(TEnum), param) ? null : string.Format(@"{0} is not a known enumeration member of {1}", param, typeof(TEnum));
		}
	}
}