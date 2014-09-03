using System.Collections.Generic;
using System.Linq;
using Coding;

namespace CSharp
{
	public class GenericDeclarationWriter : WriterWithChildren<GenericParameterWriter>, IInterfaceChild, IClassChild, IMethodChild
	{
		public GenericDeclarationWriter(IEnumerable<GenericParameterWriter> parameters = null)
		{
			if (parameters != null)
			{
				Children.AddRange(parameters);
			}
		}

		public override void Build(TokenBuilder builder)
		{
			builder.Add(Tokens.OpenAngle);

			builder.Join(Children, x => x.Build(builder), Tokens.Comma);

			builder.Add(Tokens.CloseAngle);
		}

		public void BuildConstraints(TokenBuilder builder)
		{
			builder.Join(Children.Where(x => x.Constraints.Any()), x =>
			{
				builder.Add(Tokens.Where);
				builder.Add(x.Name);
				builder.Add(Tokens.Colon);

				x.BuildConstraints(builder);
			}, Tokens.Empty);
		}
	}
}