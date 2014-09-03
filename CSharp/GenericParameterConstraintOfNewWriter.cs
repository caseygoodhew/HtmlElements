using System;
using Coding;

namespace CSharp
{
	public class GenericParameterConstraintOfNewWriter : Writer, IGenericParameterConstraint
	{
		public override void Build(TokenBuilder builder)
		{
			builder.Add(Tokens.GenericNew);
		}
	}
}