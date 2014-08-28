using System;

namespace Definition.Validation.NotImplemented
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class CoordsValidatorAttribute : NotImplementedValidatorAttribute
	{
		internal readonly Type TupleType;
		
		internal CoordsValidatorAttribute(Type tupleType)
		{
			TupleType = tupleType;
		}

		internal CoordsValidatorAttribute(Type tupleType, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(requiredAttributeType, requiredAttributeValue)
		{
			TupleType = tupleType;
		}

		internal CoordsValidatorAttribute(Type tupleType, object whenValueIs, Type requiredAttributeType, object requiredAttributeValue = null)
			: base(whenValueIs, requiredAttributeType, requiredAttributeValue)
		{
			TupleType = tupleType;
		}
	}
}