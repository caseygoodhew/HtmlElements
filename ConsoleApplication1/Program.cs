using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp;
using CSharp.Binding;
using CSharp.Writers;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			var module =
				new ModuleWriter()
				    .Using("System.Web")
					.Using("System.Casey")
					.Namespace(
						new NamespaceWriter("Casey.Goodhew")
							.Enum(
								new EnumWriter("Anything")
									.Item("Something")
									.Item("Cool")
									.Item("Happens"))
							.Enum(
								new EnumWriter("Anything")
									.Item("Something")
									.Item("Cool")
									.Item("Happens")));

		    var module2 = new ModuleWriter().Namespace(
		        "Maria.Sanchez",
		        n =>
		        n.Enum("Testing", e => e.Item("ItemOne").Item("ItemTwo"))
		            .Class(
		                "MyFristClass",
		                x =>
		                x.Generic(
		                    g =>
		                    g.Add("TSomething", p => p.WhereIsStruct())
		                        .Add("TElse", p => p.WhereIsNew().WhereIsType(new TypeParameter<int>()))))
		            .Class("AnyClass", x => x.Add(new PropertyWriter(new TypeParameter<string>(), "Awesome"))));

			
			Console.WriteLine(module.Write());

			Console.WriteLine();

			Console.WriteLine(module2.Write());

			Console.Read();
		}
	}

	
}
