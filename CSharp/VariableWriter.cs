using System;
using Coding;

namespace CSharp
{
	public class VariableWriter<T> : Writer, IInterfaceChild, IClassChild, IMethodChild where T : IParameterType
	{
		internal PrimaryAccessModifiers PrimaryAccessModifier { get; set; }

		internal string Name { get; set; }

		internal bool Static { get; set; }

		internal bool Abstract { get; set; }

		public VariableWriter(string name)
		{
			Name = name;
			PrimaryAccessModifier = PrimaryAccessModifiers.Public;
			Static = false;
		}

		public override void Build(TokenBuilder builder)
		{
			throw new NotImplementedException();
		}
	}
}