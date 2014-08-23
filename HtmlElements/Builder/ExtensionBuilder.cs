using System.Linq;
using System.Reflection;

namespace HtmlElements.Builder
{
	public class ExtensionBuilder
	{
		public void Go()
		{
			var assembly = Assembly.GetAssembly(typeof(Element));

			var attributes = assembly.GetTypes().Where(x => typeof (ElementAttribute).IsAssignableFrom(x));
			var attributeDescriptors = attributes.Select(x => new AttributeDescriptor(x));

			var elements = assembly.GetTypes().Where(x => typeof(Element).IsAssignableFrom(x));
			var elementDescriptors = elements.Select(x => new ElementDescriptor(x, attributeDescriptors));

			var test = elementDescriptors.ToList();

			int y = 0;
		}
	}
}
