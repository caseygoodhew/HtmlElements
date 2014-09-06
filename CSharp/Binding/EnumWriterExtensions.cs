using CSharp.Writers;

namespace CSharp.Binding
{
	public static class EnumWriterExtensions
	{
		public static EnumWriter HasItem(this EnumWriter @enum, string name)
		{
			@enum.Children.Add(new EnumValueWriter(@enum, name));
			return @enum;
		}
	}
}