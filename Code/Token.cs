namespace Coding
{
	public abstract class Token
	{
		private readonly string m_value;

		protected Token(string value)
		{
			m_value = value;
		}

		internal virtual string GetValue(TokenContext context)
		{
			return m_value;
		}

		internal bool Is<T>() where T : Token
		{
			return this is T;
		}
	}
}