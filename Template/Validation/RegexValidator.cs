using System.Text.RegularExpressions;
using Template.Elements;

namespace Template.Validation
{
	public abstract class RegexValidator : Validator<string>
	{
		private readonly Regex regex;

		private readonly string failureMessage;

		private readonly bool messageHasParam;

		protected RegexValidator(string regex, string failureMessage)
			: this(regex, false, failureMessage)
		{
		}

		protected RegexValidator(string regex, bool ignoreCase, string failureMessage)
			: this(ignoreCase ? new Regex(regex, RegexOptions.IgnoreCase) : new Regex(regex), failureMessage)
		{
		}

		protected RegexValidator(Regex regex, string failureMessage)
		{
			this.regex = regex;
			this.failureMessage = failureMessage;
			messageHasParam = failureMessage.Contains("{0}");
		}

		public override string Validate(Element el, string param)
		{
			if (regex.IsMatch(param))
			{
				return null;
			}

			return messageHasParam ? string.Format(failureMessage, param) : failureMessage;
		}
	}
}