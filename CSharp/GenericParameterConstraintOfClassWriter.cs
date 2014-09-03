using System;
using Coding;

namespace CSharp
{
	public class GenericParameterConstraintOfClassWriter : Writer, IGenericParameterConstraint
	{
		public override void Build(TokenBuilder builder)
		{
			builder.Add(Tokens.Class);
		}
	}
}