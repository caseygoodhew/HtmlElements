using System;

namespace Definition
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class AppliesToElementWithoutAttachAttribute : AppliesToElementAttribute
	{
		public readonly object ValueToSet;

		public AppliesToElementWithoutAttachAttribute(Type type, object valueToSet, string referenceUrl) : base(type, referenceUrl)
		{
			ValueToSet = valueToSet;
		}
	}
}