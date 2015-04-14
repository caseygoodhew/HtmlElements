using System;

namespace Definition
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class RestrictChildrenToAttribute : Attribute
	{
		public readonly Type ChildType;

		public RestrictChildrenToAttribute(Type type)
		{
			ChildType = type;
		}
	}
}