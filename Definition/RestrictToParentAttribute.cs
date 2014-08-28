using System;

namespace Definition
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class RestrictToParentAttribute : Attribute
	{
		public readonly Type ParentType;

		public RestrictToParentAttribute(Type type)
		{
			ParentType = type;
		}
	}
}