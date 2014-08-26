using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TheGoal;
using TheGoal.Generated;
using TheGoal.Programmed;

namespace TestingTheGoal
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(new Div().Class("casey").Class("goodhew").ToString());
            }
            catch (AttributeValidationException ex)
            {
                ex.ValidationErrors.ToList().ForEach(Console.WriteLine);
            }
            
            Console.ReadKey();
        }
    }

    public static class ElementExtensions
    {
        public static TElement Class<TElement>(this TElement element, string value) where TElement : Element
        {
            Reveal.AddAttribute(element, new ClassAttributeInstance(value));
            return element;
        }
    }
}
