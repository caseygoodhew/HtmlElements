using System;

namespace Definition.Validation
{
	[AttributeUsage(AttributeTargets.Field)]
    internal class ValidatorForEnumAttribute : Attribute
    {
        public readonly Type EnumType;

        public ValidatorForEnumAttribute(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type is not an Enum", "enumType");
            }

            EnumType = enumType;
        }
    }
}
