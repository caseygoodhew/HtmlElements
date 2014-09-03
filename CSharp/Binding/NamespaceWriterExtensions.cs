using System;

using CSharp.Writers;

namespace CSharp.Binding
{
	public static class NamespaceWriterExtensions
	{
		public static NamespaceWriter Enum(this NamespaceWriter @namespace, EnumWriter @enum)
		{
			@namespace.Children.Add(@enum);
			return @namespace;
		}

		public static NamespaceWriter Enum(this NamespaceWriter @namespace, string @enum, Action<EnumWriter> configAction = null)
		{
			var enumWriter = new EnumWriter(@enum);

			if (configAction != null)
			{
				configAction.Invoke(enumWriter);
			}

			return @namespace.Enum(enumWriter);
		}

		public static NamespaceWriter Class(this NamespaceWriter @namespace, string @class, Action<ClassWriter> configAction = null)
		{
			var classWriter = new ClassWriter(@class);
			
			if (configAction != null)
			{
				configAction.Invoke(classWriter);
			}

			return @namespace.Class(classWriter);
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
	}
}
