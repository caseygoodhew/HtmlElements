﻿using System;

namespace CSharp.Binding
{
	public static class ModuleWriterExtensions
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

		public static ModuleWriter Namespace(this ModuleWriter module, string @namespace, Action<NamespaceWriter> configAction = null)
		{
			var namespaceWriter = new NamespaceWriter(@namespace);
			
			if (configAction != null)
			{
				configAction.Invoke(namespaceWriter);
			}
			
			return module.Namespace(namespaceWriter);
		}
	}
}