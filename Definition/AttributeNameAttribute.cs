using System;

namespace Definition
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class AttributeNameAttribute : Attribute
	{
		public readonly string Name;

		public AttributeNameAttribute(string name)
		{
			Name = name;
		}
	}
}