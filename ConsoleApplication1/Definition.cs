using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public enum WrapIn
	{
		Nothing,
		Curlies
	}

	public enum SpaceBetween
	{
		Yes,
		No
	}

	public static class CodeBlockExtensions
	{
		public static CodeBlock Indent(this CodeBlock codeBlock, WrapIn wrapIn = WrapIn.Nothing)
		{
			codeBlock.WrapIn = wrapIn;
			return codeBlock;
		}

		public static CodeBlock NoSpaceBetween(this CodeBlock codeBlock)
		{
			codeBlock.SpaceBetween = SpaceBetween.No;
			return codeBlock;
		}

		public static CodeBlock Add(this CodeBlock codeBlock, CodeBlock child)
		{
			codeBlock.Children.Add(child);
			return codeBlock;
		}

		public static CodeBlock Add(this CodeBlock codeBlock, CodeBlock[] children)
		{
			codeBlock.Children.AddRange(children);
			return codeBlock;
		}
	}

	public class CodeBlock
	{
		public string Value { get; set; }

		public WrapIn? WrapIn { get; set; }

		public List<CodeBlock> Children { get; set; }

		public SpaceBetween SpaceBetween { get; set; }

		public CodeBlock(string value = null)
		{
			Value = value;
			SpaceBetween = SpaceBetween.Yes;
			Children = new List<CodeBlock>();
		}
		
		/*public CodeBlock(string value, params CodeBlock[] children) : this(children)
		{
			Value = value;
			SpaceBetween = SpaceBetween.Yes;
		}
		
		public CodeBlock(params CodeBlock[] children)
		{
			Children = children.ToList();
		}

		public CodeBlock(string value, params CodeBlock[][] children) : this(children)
		{
			Value = value;
			SpaceBetween = SpaceBetween.Yes;
		}

		public CodeBlock(params CodeBlock[][] children)
		{
			Children = children.SelectMany(x => x).ToList();
		}

		public CodeBlock(WrapIn wrapIn, params CodeBlock[] children)
			: this(children)
		{
			WrapIn = wrapIn;
		}

		public CodeBlock(string value, WrapIn wrapIn, params CodeBlock[] children)
			: this(wrapIn, children)
		{
			Value = value;
			SpaceBetween = SpaceBetween.Yes;
		}

		public CodeBlock(WrapIn wrapIn, params CodeBlock[][] children)
			: this(children)
		{
			WrapIn = wrapIn;
		}

		public CodeBlock(string value, WrapIn wrapIn, params CodeBlock[][] children)
			: this(wrapIn, children)
		{
			Value = value;
			SpaceBetween = SpaceBetween.Yes;
		}

		public CodeBlock(string value) 
		{
			Value = value;
			Children = new List<CodeBlock>();
			SpaceBetween = SpaceBetween.Yes;
		}*/

		public override string ToString()
		{
			var builder = new StringBuilder();
			Write(builder, 0);
			return builder.ToString();
		}

		public void Write(StringBuilder builder, int indent)
		{
			var indentString = string.Concat(Enumerable.Repeat("    ", indent));
			
			if (!string.IsNullOrEmpty(Value))
			{
				builder.Append(indentString);
				builder.AppendLine(Value);
			}

			var indentChildren = indent;
			if (WrapIn != null)
			{
				builder.Append(indentString);
				builder.AppendLine(GetOpeningIndentChar());
				indentChildren++;
			}

			for (var i = 0; i < Children.Count; i++)
			{
				Children[i].Write(builder, indentChildren);

				if (SpaceBetween == SpaceBetween.Yes && i + 1 < Children.Count)
				{
					builder.AppendLine();
				}
			}

			if (WrapIn != null)
			{
				builder.Append(indentString);
				builder.AppendLine(GetClosingIndentChar());
			}
		}

		private string GetOpeningIndentChar()
		{
			switch (WrapIn)
			{
				case ConsoleApplication1.WrapIn.Curlies:
					return "{";
				case null:
					throw new InvalidOperationException();
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private string GetClosingIndentChar()
		{
			switch (WrapIn)
			{
				case ConsoleApplication1.WrapIn.Curlies:
					return "}";
				case null:
					throw new InvalidOperationException();
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}

	public enum AccessModifiers
	{
		Public,
		Private,
		Protected,
		Internal
	}

	public enum ValueTypes
	{
		Bool,
		//Byte,
		Char,
		Decimal,
		//Double,
		//Float,
		Int,
		Long,
		//sbyte,
		//short,
		//uint,
		//ulong,
		//ushort,
	}

	public interface IWriter
	{
		CodeBlock GetCodeBlock();
	}
	
	public abstract class Writer : IWriter
	{
		public string Write()
		{
			return GetCodeBlock().ToString();
		}

		public abstract CodeBlock GetCodeBlock();
	}

	public abstract class WriterWithChildren<TChild> : Writer where TChild : IWriter
	{
		public List<TChild> Children { get; set; }
		
		protected WriterWithChildren()
		{
			Children = new List<TChild>();
		}

		protected CodeBlock[] GetChildCodeBlocks<T>() where T : IWriter
		{
			return Children.OfType<T>().Select(x => x.GetCodeBlock()).ToArray();
		}
	}

	public interface IModuleChild : IWriter
	{
	}

	public interface INamespaceChild : IWriter
	{
	}

	public interface IClassChild : IWriter
	{
	}

	public interface IParameterType : IWriter
	{
	}

	public interface IInterfaceChild : IWriter
	{
	}

	public interface IMethodChild : IWriter
	{
	}

	public interface IGenericDeclarationChild : IWriter
	{
	}

	public interface IGenericParameterConstraint : IWriter
	{
	}

	public class ModuleWriter : WriterWithChildren<IModuleChild>
	{
		public override CodeBlock GetCodeBlock()
		{
			return new CodeBlock()
				.Add(GetChildCodeBlocks<UsingWriter>())
				.Add(GetChildCodeBlocks<NamespaceWriter>());
		}
	}

	public class UsingWriter : Writer, IModuleChild
	{
		public NamespaceWriter Namespace { get; set; }

		public UsingWriter(string @namespace)
		{
			Namespace = new NamespaceWriter(@namespace);
		}

		public UsingWriter(NamespaceWriter @namespace)
		{
			Namespace = @namespace;
		}

		public override CodeBlock GetCodeBlock()
		{
			return new CodeBlock(string.Format("using {0};", Namespace.Name));
		}
	}

	public class NamespaceWriter : WriterWithChildren<INamespaceChild>, IModuleChild
	{
		public string Name { get; set; }

		public NamespaceWriter(string name)
		{
			Name = name;
		}

		public override CodeBlock GetCodeBlock()
		{
			return new CodeBlock(
				string.Format("namespace {0}", Name))
				.Indent(WrapIn.Curlies)
				.Add(GetChildCodeBlocks<EnumWriter>())
				.Add(GetChildCodeBlocks<InterfaceWriter>())
				.Add(GetChildCodeBlocks<ClassWriter>());
		}
	}

	public class EnumWriter : WriterWithChildren<EnumValueWriter>, INamespaceChild
	{
		public AccessModifiers AccessModifier { get; set; }

		public string Name { get; set; }

		public EnumWriter(string name)
		{
			Name = name;
			AccessModifier = AccessModifiers.Public;
		}

		public override CodeBlock GetCodeBlock()
		{
			return new CodeBlock(
				string.Format("{0} enum {1}", AccessModifier.ToString().ToLower(), Name))
				.Indent(WrapIn.Curlies)
				.NoSpaceBetween()
				.Add(GetChildCodeBlocks<EnumValueWriter>());
		}
	}

	public class EnumValueWriter : Writer
	{
		public EnumWriter Enum { get; set; }

		public string Name { get; set; }

		public EnumValueWriter(EnumWriter @enum, string name)
		{
			Enum = @enum;
			Name = name;
		}

		public override CodeBlock GetCodeBlock()
		{
			return new CodeBlock(string.Format("{0},", Name));
		}
	}

	public class ClassWriter : Writer, INamespaceChild, IParameterType
	{
		public AccessModifiers AccessModifier { get; set; }

		public string Name { get; set; }

		public bool Static { get; set; }

		public bool Abstract { get; set; }

		public List<IParameterType> GenericParameters { get; set; }

		public ClassWriter(string name)
		{
			Name = name;
			AccessModifier = AccessModifiers.Public;
			Static = false;
		}

		public override CodeBlock GetCodeBlock()
		{
			throw new NotImplementedException();
		}
	}

	public class GenericDeclarationWriter : Writer, IClassChild, IMethodChild
	{
		public IList<GenericParameterWriter> Parameters { get; set; }

		public GenericDeclarationWriter(IList<GenericParameterWriter> parameters)
		{
			Parameters = parameters;
		}

		public override CodeBlock GetCodeBlock()
		{
			throw new NotImplementedException();
		}
	}

	public class GenericParameterWriter : Writer, IGenericDeclarationChild
	{
		public string Name { get; set; }

		public List<IGenericParameterConstraint> Constraints { get; set; }

		public GenericParameterWriter(string name)
		{
			Name = name;
		}

		public override CodeBlock GetCodeBlock()
		{
			throw new NotImplementedException();
		}
	}

	public class GenericParameterConstraintOfTypeWriter<T> : Writer, IGenericParameterConstraint where T : IParameterType
	{
		public override CodeBlock GetCodeBlock()
		{
			throw new NotImplementedException();
		}
	}

	public class GenericParameterConstraintOfNewWriter : Writer, IGenericParameterConstraint
	{
		public override CodeBlock GetCodeBlock()
		{
			throw new NotImplementedException();
		}
	}

	public class InterfaceWriter : Writer, INamespaceChild
	{
		public AccessModifiers AccessModifier { get; set; }

		public string Name { get; set; }

		public List<IParameterType> GenericParameters { get; set; }

		public InterfaceWriter(string name)
		{
			Name = name;
			AccessModifier = AccessModifiers.Public;
		}

		public override CodeBlock GetCodeBlock()
		{
			throw new NotImplementedException();
		}
	}

	public class VariableWriter<T> : Writer, IInterfaceChild, IClassChild, IMethodChild where T : IParameterType
	{
		public AccessModifiers AccessModifier { get; set; }

		public string Name { get; set; }

		public bool Static { get; set; }

		public bool Abstract { get; set; }

		public VariableWriter(string name)
		{
			Name = name;
			AccessModifier = AccessModifiers.Public;
			Static = false;
		}

		public override CodeBlock GetCodeBlock()
		{
			throw new NotImplementedException();
		}
	}

	public class ValueTypeWriter : Writer, IParameterType
	{
		public ValueTypes ValueType { get; set; }

		public ValueTypeWriter(ValueTypes valueType)
		{
			ValueType = valueType;
		}

		public override CodeBlock GetCodeBlock()
		{
			throw new NotImplementedException();
		}
	}

	
}
