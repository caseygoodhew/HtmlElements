using System;

using CSharp.Writers;

namespace CSharp.Binding
{
	public static class NamespaceWriterExtensions
	{
		public static NamespaceWriter HasEnum(this NamespaceWriter @namespace, EnumWriter @enum)
		{
			@namespace.Children.Add(@enum);
			return @namespace;
		}

		public static NamespaceWriter HasEnum(this NamespaceWriter @namespace, string @enum, Action<EnumWriter> configAction = null)
		{
			var enumWriter = new EnumWriter(@enum);

			if (configAction != null)
			{
				configAction.Invoke(enumWriter);
			}

			return @namespace.HasEnum(enumWriter);
		}

		public static NamespaceWriter HasClass(this NamespaceWriter @namespace, string @class, Action<ClassWriter> configAction = null)
		{
			var classWriter = new ClassWriter(@class);
			
			if (configAction != null)
			{
				configAction.Invoke(classWriter);
			}

			return @namespace.HasClass(classWriter);
		}

		public static NamespaceWriter HasClass(this NamespaceWriter @namespace, ClassWriter @class)
		{
			@namespace.Children.Add(@class);
			return @namespace;
		}

		public static NamespaceWriter HasInterface(this NamespaceWriter @namespace, InterfaceWriter @interface)
		{
			@namespace.Children.Add(@interface);
			return @namespace;
		}
	}
}
