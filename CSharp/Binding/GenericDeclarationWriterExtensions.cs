using System;
using System.Linq;

namespace CSharp.Binding
{
	public static class GenericDeclarationWriterExtensions
	{
		public static GenericDeclarationWriter Add(this GenericDeclarationWriter genericDeclaration, GenericParameterWriter genericParameterWriter)
		{
			genericDeclaration.Children.Add(genericParameterWriter);
			return genericDeclaration;
		}

		public static GenericDeclarationWriter Add(this GenericDeclarationWriter genericDeclaration, string typeName, params IGenericParameterConstraint[] constraints)
		{
			var genericParameter = new GenericParameterWriter(typeName)
			{
				Constraints = constraints.ToList()
			};

			return genericDeclaration.Add(genericParameter);
		}

		public static GenericDeclarationWriter Add(this GenericDeclarationWriter genericDeclaration, string typeName, Action<GenericParameterWriter> configAction)
		{
			var genericParameter = new GenericParameterWriter(typeName);
			configAction.Invoke(genericParameter);
			return genericDeclaration.Add(genericParameter);
		}
	}
}