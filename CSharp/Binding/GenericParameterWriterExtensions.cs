using System.Linq;

namespace CSharp.Binding
{
	public static class GenericParameterWriterExtensions
	{
		public static GenericParameterWriter WhereIsNew(this GenericParameterWriter genericParameter)
		{
			genericParameter.Constraints.Add(new GenericParameterConstraintOfNewWriter());
			return genericParameter;
		}

		public static GenericParameterWriter WhereIsClass(this GenericParameterWriter genericParameter)
		{
			genericParameter.Constraints.Add(new GenericParameterConstraintOfClassWriter());
			return genericParameter;
		}

		public static GenericParameterWriter WhereIsStruct(this GenericParameterWriter genericParameter)
		{
			genericParameter.Constraints.Add(new GenericParameterConstraintOfStructWriter());
			return genericParameter;
		}

		public static GenericParameterWriter WhereIsType<T>(this GenericParameterWriter genericParameter) where T : IParameterType, new()
		{
			genericParameter.Constraints.Add(new GenericParameterConstraintOfTypeWriter<T>());
			return genericParameter;
		}
	}
}