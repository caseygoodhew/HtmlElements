using System;

namespace Definition
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	internal class ReferenceAttribute : Attribute
	{
		public readonly string _url;

		public ReferenceAttribute(string url)
		{
			_url = url;
		}
	}
}