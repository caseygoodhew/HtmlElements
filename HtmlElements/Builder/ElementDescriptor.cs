using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlElements.Builder
{
	public class ElementDescriptor
	{
		public readonly Type Type;

		internal ElementDescriptor(Type type, IEnumerable<AttributeDescriptor> attributeDescriptors)
		{
			Type = type;
			AttributeDescriptors = attributeDescriptors.Where(x => x.Type.GetCustomAttributes(typeof(AppliesToElement), true).Cast<AppliesToElement>().Any(a => a .ElementType == Type));
		}

		public bool IsRootElement
		{
			get { return Implments<IRootElement>(); }
		}

		public bool IsDocumentMetadataElement
		{
			get { return Implments<IDocumentMetadataElement>(); }
		}

		public bool IsScriptingElement
		{
			get { return Implments<IDocumentMetadataElement>(); }
		}

		public bool IsSectionElement
		{
			get { return Implments<ISectionElement>(); }
		}

		public bool IsContentGroupingElement
		{
			get { return Implments<IContentGroupingElement>(); }
		}

		public bool IsSemanticTextElement
		{
			get { return Implments<ISemanticTextElement>(); }
		}

		public bool IsEmbeddedContentElement
		{
			get { return Implments<IEmbeddedContentElement>(); }
		}

		public bool IsTableElement
		{
			get { return Implments<ITableElement>(); }
		}

		public bool IsFormElement
		{
			get { return Implments<IFormElement>(); }
		}

		public bool IsInteractiveElement
		{
			get { return Implments<IInteractiveElement>(); }
		}

		public bool IsFrequentElement
		{
			get { return Implments<IFrequentElement>(); }
		}

		public readonly IEnumerable<AttributeDescriptor> AttributeDescriptors;
		
		private bool Implments<TInterface>()
		{
			var interfaceType = typeof (TInterface);
			return Type.GetInterfaces().Any(x => x == interfaceType);
		}
	}
}
