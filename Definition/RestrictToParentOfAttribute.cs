using System;

namespace Definition
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class RestrictToParentOfAttribute : Attribute
	{
		public readonly Type ParentType;

		public RestrictToParentOfAttribute(Type type)
		{
			ParentType = type;
		}
	}
}