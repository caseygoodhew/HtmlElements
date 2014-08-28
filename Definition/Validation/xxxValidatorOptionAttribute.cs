using System;

namespace Definition.Validation
{
	[AttributeUsage(AttributeTargets.Field)]
	internal class ValidatorOptionAttribute : Attribute
	{
		public readonly string Key;

		public readonly object Value;

		public ValidatorOptionAttribute(string key, object value)
		{
			Key = key;
			Value = value;
		}
	}
}