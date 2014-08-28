using System;
using System.Collections.Generic;
using Definition.Elements;

namespace Definition
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class ElementTypeAttribute : Attribute
	{
		internal readonly IEnumerable<ElementType> ElementTypes;

		public ElementTypeAttribute(params ElementType[] elementTypes)
		{
			ElementTypes = elementTypes;
		}
	}
}
