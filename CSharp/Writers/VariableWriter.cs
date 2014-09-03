using System;

using Coding;

namespace CSharp.Writers
{
	public class VariableWriter<T> : Writer, IInterfaceChild, IClassChild, IMethodChild where T : IParameterTypeWriter
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