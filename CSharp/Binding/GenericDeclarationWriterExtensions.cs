using System;
using System.Linq;

using CSharp.Writers;

namespace CSharp.Binding
{
	public static class GenericDeclarationWriterExtensions
	{
		public static GenericDeclarationWriter HasParameter(this GenericDeclarationWriter genericDeclaration, GenericParameterWriter genericParameterWriter)
		{
			genericDeclaration.Children.Add(genericParameterWriter);
			return genericDeclaration;
		}

		public static GenericDeclarationWriter HasParameter(this GenericDeclarationWriter genericDeclaration, string typeName, params IGenericParameterConstraint[] constraints)
		{
			var genericParameter = new GenericParameterWriter(typeName)
			{
				Constraints = constraints.ToList()
			};

			return genericDeclaration.HasParameter(genericParameter);
		}

		public static GenericDeclarationWriter HasParameter(this GenericDeclarationWriter genericDeclaration, string typeName, Action<GenericParameterWriter> configAction)
		{
			var genericParameter = new GenericParameterWriter(typeName);
			configAction.Invoke(genericParameter);
			return genericDeclaration.HasParameter(genericParameter);
		}
	}
}