namespace Template.Validation
{
	public class IdValidator : RegexValidator
	{
		public IdValidator() : base("^[A-Za-z][-A-Za-z0-9_:.]*$", "{0} is an invalid id value")
		{
		}
	}
}