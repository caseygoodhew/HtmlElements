using System;
using Coding;

namespace CSharp
{
	public class GenericParameterConstraintOfStructWriter : Writer, IGenericParameterConstraint
	{
		public override void Build(TokenBuilder builder)
		{
			builder.Add(Tokens.Struct);
		}
	}
}