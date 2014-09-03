namespace CSharp
{
	public class ValueTypeParameter<T> : IParameterType
	{
		public string Name
		{
			get { return typeof (T).Name; }
		}
	}
}