using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			var module =
				new ModuleWriter()
				    .Using("System.Web")
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

			var module2 = new ModuleWriter()
				.Namespace("Maria.Sanchez", n =>
					n.Enum("Testing", e => e.Item("ItemOne").Item("ItemTwo"))
					 .Enum("Testing", e => e.Item("ItemOne").Item("ItemTwo")));
			
			Console.WriteLine(module.Write());

			Console.WriteLine();

			Console.WriteLine(module2.Write());

			Console.Read();
		}
	}

	
}
