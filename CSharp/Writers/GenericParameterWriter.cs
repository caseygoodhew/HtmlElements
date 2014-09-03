using System.Collections.Generic;

using Coding;

namespace CSharp.Writers
{
	public class GenericParameterWriter : Writer, IGenericDeclarationChild
	{
		internal string Name { get; set; }

		internal List<IGenericParameterConstraint> Constraints { get; set; }

		public GenericParameterWriter(string name)
		{
			Name = name;
			Constraints = new List<IGenericParameterConstraint>();
		}

		public override void Build(TokenBuilder builder)
		{
			builder.Add(Name);
		}

		public void BuildConstraints(TokenBuilder builder)
		{
			builder.Join(Constraints, x => x.Build(builder), Token.Comma);
		}
	}
}