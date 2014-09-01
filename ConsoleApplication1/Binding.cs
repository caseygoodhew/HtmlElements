using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public static class Binding
	{
		public static ModuleWriter Using(this ModuleWriter module, string @namespace)
		{
			module.Children.Add(new UsingWriter(@namespace));
			return module;
		}

		public static ModuleWriter Using(this ModuleWriter module, NamespaceWriter @namespace)
		{
			module.Children.Add(new UsingWriter(@namespace));
			return module;
		}

		public static ModuleWriter Namespace(this ModuleWriter module, NamespaceWriter @namespace)
		{
			module.Children.Add(@namespace);
			return module;
		}

		public static ModuleWriter Namespace(this ModuleWriter module, string @namespace, Action<NamespaceWriter> configAction)
		{
			var namespaceWriter = new NamespaceWriter(@namespace);
			configAction.Invoke(namespaceWriter);
			return module.Namespace(namespaceWriter);
		}

		public static NamespaceWriter Enum(this NamespaceWriter @namespace, EnumWriter @enum)
		{
			@namespace.Children.Add(@enum);
			return @namespace;
		}

		public static NamespaceWriter Enum(this NamespaceWriter @namespace, string @enum, Action<EnumWriter> configAction)
		{
			var enumWriter = new EnumWriter(@enum);
			configAction.Invoke(enumWriter);
			return @namespace.Enum(enumWriter);
		}

		public static NamespaceWriter Class(this NamespaceWriter @namespace, ClassWriter @class)
		{
			@namespace.Children.Add(@class);
			return @namespace;
		}

		public static NamespaceWriter Interface(this NamespaceWriter @namespace, InterfaceWriter @interface)
		{
			@namespace.Children.Add(@interface);
			return @namespace;
		}

		public static EnumWriter Item(this EnumWriter @enum, string name)
		{
			@enum.Children.Add(new EnumValueWriter(@enum, name));
			return @enum;
		}
	}
}
