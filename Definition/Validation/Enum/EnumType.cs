using System;

namespace Definition.Validation.Enum
{
    internal static class EnumType
    {
        internal static Type Get<T>() where T : struct, IConvertible
        {
            var enumType = typeof(T);

            if (!enumType.IsEnum)
            {
                throw new ArgumentException(string.Format("{0} is not an enum.", enumType.Name));
            }

            return enumType;
        }
    }
}
