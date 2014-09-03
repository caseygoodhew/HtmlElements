using System.Collections.Generic;
using System.Linq;

using Coding;

namespace CSharp.Writers
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
			builder.Add(Token.OpenAngle);

			builder.Join(Children, x => x.Build(builder), Token.Comma);

			builder.Add(Token.CloseAngle);
		}

		public void BuildConstraints(TokenBuilder builder)
		{
			builder.Join(Children.Where(x => x.Constraints.Any()), x =>
			{
				builder.Add(Token.Where);
				builder.Add(x.Name);
				builder.Add(Token.Colon);

				x.BuildConstraints(builder);
			}, Token.Empty);
		}
	}
}