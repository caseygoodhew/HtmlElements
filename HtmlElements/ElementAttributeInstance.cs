using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlElements
{
    public abstract class ElementAttributeInstance<TElementAttribute> where TElementAttribute : ElementAttribute
    {
        public readonly TElementAttribute ElementAttribute;

        protected ElementAttributeInstance(TElementAttribute elementAttribute)
        {
            ElementAttribute = elementAttribute;
        }
    }
}
