using System;
using System.Linq;
using Coding;

namespace CSharp.Binding
{
	public static class ClassWriterExtensions
	{
		public static ClassWriter Public(this ClassWriter @class)
		{
			@class.PrimaryAccessModifier = PrimaryAccessModifiers.Public;
			return @class;
		}

		public static ClassWriter Private(this ClassWriter @class)
		{
			@class.PrimaryAccessModifier = PrimaryAccessModifiers.Private;
			return @class;
		}

		public static ClassWriter Protected(this ClassWriter @class)
		{
			@class.PrimaryAccessModifier = PrimaryAccessModifiers.Protected;
			return @class;
		}

		public static ClassWriter Internal(this ClassWriter @class)
		{
			@class.PrimaryAccessModifier = PrimaryAccessModifiers.Internal;
			return @class;
		}

		public static ClassWriter Abstract(this ClassWriter @class)
		{
			if (@class.SecondaryAccessModifier.HasValue)
			{
				throw new InvalidOperationException();
			}

			@class.SecondaryAccessModifier = SecondaryAccessModifiers.Abstract;
			return @class;
		}

		public static ClassWriter Static(this ClassWriter @class)
		{
			if (@class.SecondaryAccessModifier.HasValue)
			{
				throw new InvalidOperationException();
			}

			@class.SecondaryAccessModifier = SecondaryAccessModifiers.Static;
			return @class;
		}

		public static ClassWriter Readonly(this ClassWriter @class)
		{
			if (@class.SecondaryAccessModifier.HasValue)
			{
				throw new InvalidOperationException();
			}

			@class.SecondaryAccessModifier = SecondaryAccessModifiers.Readonly;
			return @class;
		}

		public static ClassWriter StaticReadonly(this ClassWriter @class)
		{
			if (@class.SecondaryAccessModifier.HasValue)
			{
				throw new InvalidOperationException();
			}

			@class.SecondaryAccessModifier = SecondaryAccessModifiers.StaticReadonly;
			return @class;
		}

		public static ClassWriter Generic(this ClassWriter @class, GenericDeclarationWriter genericDeclaration)
		{
			@class.GenericDeclaration = genericDeclaration;
			return @class;
		}

		public static ClassWriter Generic(this ClassWriter @class, params GenericParameterWriter[] genericParameterWriters)
		{
			return @class.Generic(new GenericDeclarationWriter(genericParameterWriters.ToList()));
		}

		public static ClassWriter Generic(this ClassWriter @class, Action<GenericDeclarationWriter> configAction)
		{
			var genericDeclaration = new GenericDeclarationWriter();
			configAction.Invoke(genericDeclaration);
			return @class.Generic(genericDeclaration);
		}
	}
}