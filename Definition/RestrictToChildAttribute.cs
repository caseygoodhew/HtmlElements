using System;

namespace Definition
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class RestrictToChildAttribute : Attribute
	{
		public readonly Type ChildType;

		public RestrictToChildAttribute(Type type)
		{
			ChildType = type;
		}
	}
}