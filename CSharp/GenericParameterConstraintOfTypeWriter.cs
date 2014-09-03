using System;
using Coding;

namespace CSharp
{
	public class GenericParameterConstraintOfTypeWriter<T> : Writer, IGenericParameterConstraint where T : IParameterType, new()
	{
		public override void Build(TokenBuilder builder)
		{
			builder.Add(new T().Name);
		}
	}
}