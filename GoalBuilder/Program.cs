using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoalBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new AssemblyReader();
            reader.Read(typeof(Definition.ElementType));
            //string @namespace = "Definition";

            //var q = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.Namespace == @namespace);

            //q.ToList().ForEach(t => Console.WriteLine(t.Name));

            //Console.ReadKey();
        }
    }
}
