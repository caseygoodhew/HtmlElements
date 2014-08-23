using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace HtmlElements
{
	public static class TestPage
	{
		public static void Test()
		{
			new Div().Class("some-class").Child(
				new TextInput().Class("form-element").Pattern(new Regex(""))
			).Child(
				new TextInput().Class("form-element").Pattern(new Regex(""))
			);

			
		}
	}

	public static class ElementExensions
	{
		public static TElement Class<TElement>(this TElement el, string className) where TElement : Element
		{
			return el;
		}
	}

	public static class DivExtensions
	{
		public static TElement Child<TElement>(this TElement el, Element child) where TElement : Div
		{
			return el;
		}
	}

	public static class TextTypeInputExtensions
	{
		public static TElement Pattern<TElement>(this TElement el, Regex regex) where TElement : TextTypeInput
		{
			return el;
		}
	}
}
