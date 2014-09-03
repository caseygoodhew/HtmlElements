namespace CSharp.Binding
{
	public static class EnumWriterExtensions
	{
		public static EnumWriter Item(this EnumWriter @enum, string name)
		{
			@enum.Children.Add(new EnumValueWriter(@enum, name));
			return @enum;
		}
	}
}