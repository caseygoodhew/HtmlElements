using System;
using Coding.Writers;

namespace Coding.Binding
{
	public static class EnumWriterExtensions
	{
		public static EnumWriter HasItem(this EnumWriter @enum, string name)
		{
			return @enum.HasItem(new EnumValueWriter(@enum, name));
		}

        public static EnumWriter HasItem(this EnumWriter @enum, EnumValueWriter enumValue)
        {
            if (enumValue.ParentEnum != @enum)
            {
                throw new InvalidOperationException("enumValue.ParentEnum to enum (this) mismatch.");
            }

            @enum.EnumValues.Add(enumValue);
            return @enum;
        }
	}
}