using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGoal.Programmed
{
    public abstract class Element
    {
        private readonly List<AttributeInstance> attributeInstances = new List<AttributeInstance>();

        private bool hasChanged;
        
        internal readonly string TagName;

        protected Element(string tagName)
        {
            TagName = tagName;
        }

        internal virtual void AddAttributeInstance(AttributeInstance attributeInstance)
        {
            attributeInstances.Add(attributeInstance);
            hasChanged = true;
        }

        public override string ToString()
        {
            if (hasChanged)
            {
                Validate();
            }

            var attributeDict = attributeInstances.GroupBy(x => x.GetName()).ToDictionary(x => x.Key, x => x.ToList());

            var builder = new StringBuilder();

            builder.Append("<");
            builder.Append(TagName);
            
            foreach (var kvp in attributeDict)
            {
                builder.Append(" ");
                builder.Append(kvp.Key);
                builder.Append("=\"");

                var separator = string.Empty;
                foreach (var attributeInstance in kvp.Value)
                {
                    builder.Append(separator);
                    builder.Append(attributeInstance.GetValue());
                    separator = " ";
                }

                builder.Append("\"");
            }

            builder.Append(" ");
            builder.Append(">");
            builder.Append("Haha!");
            builder.Append("</");
            builder.Append(TagName);
            builder.Append(">");

            return builder.ToString();
        }

        internal void Validate()
        {
            var results = new List<ValidationError>();

            attributeInstances.ForEach(
                x =>
                    {
                        var result = x.Validate(this);
                        if (!string.IsNullOrEmpty(result))
                        {
                            results.Add(new ValidationError(x, result));
                        }
                    });

            if (results.Any())
            {
                throw new AttributeValidationException(results);

            }
        }
    }
}