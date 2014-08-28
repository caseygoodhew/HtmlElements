using System;
using Definition.Elements;

namespace Definition
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	internal class AppliesToElementAttribute : ReferenceAttribute
	{
		public readonly Type ElementType;

		public AppliesToElementAttribute(Type type, string referenceUrl) : base(referenceUrl)
		{
			if (!typeof (ElementDefinition).IsAssignableFrom(type))
			{
				throw new ArgumentException(string.Format("{0} is not derived from ElementDefinition", type.Name), "type");
			}
			
			ElementType = type;
		}
	}
}