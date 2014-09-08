using Coding.Writers;

namespace Coding.Binding
{
	public static class EnumWriterExtensions
	{
		public static EnumWriter HasItem(this EnumWriter @enum, string name)
		{
			@enum.EnumValues.Add(new EnumValueWriter(@enum, name));
			return @enum;
		}
	}
}