using Coding;

namespace CSharp
{
	public class TypeParameter<T> : IParameterTypeWriter
	{
		public string Name
		{
			get { return typeof (T).Name; }
		}

	    public void BuildParameterTypeName(TokenBuilder builder)
	    {
	        builder.Add(Name);
	    }
	}
}