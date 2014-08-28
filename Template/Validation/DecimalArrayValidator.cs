using System.Collections.Generic;
using Template.Elements;

namespace Template.Validation
{
	public class DecimalArrayValidator : Validator<IEnumerable<decimal>>
	{
		public override string Validate(Element el, IEnumerable<decimal> param)
		{
			return null;
		}
	}
}