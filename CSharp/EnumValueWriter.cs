using Coding;

namespace CSharp
{
	public class EnumValueWriter : Writer
	{
		internal EnumWriter Enum { get; set; }

		internal string Name { get; set; }

		public EnumValueWriter(EnumWriter @enum, string name)
		{
			Enum = @enum;
			Name = name;
		}

		public override void Build(TokenBuilder builder)
		{
			builder.Add(Name);
		}
	}
}