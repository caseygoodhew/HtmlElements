using System;
using System.Collections.Generic;

using Coding;

namespace CSharp.Writers
{
	public class InterfaceWriter : Writer, INamespaceChild
	{
		internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

		internal string Name { get; set; }

		internal List<IParameterTypeWriter> GenericParameters { get; set; }

		public InterfaceWriter(string name)
		{
			Name = name;
			PrimaryAccessModifier = PrimaryAccessModifiers.Public;
		}

		public override void Build(TokenBuilder builder)
		{
			throw new NotImplementedException();
		}
	}
}