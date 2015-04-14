using System;
using System.Collections.Generic;
using Definition;
using Definition.Attributes;
using Definition.Enums;
using Definition.Validation;

namespace GoalBuilder
{
    internal class ElementInfo
    {
        public ElementInfo InheritedFrom { get; set; }
        
        public string Tag { get; set; }

        public bool IsAbstract { get; set; }

        public Structure Structure { get; set; }

        public string Reference { get; set; }

        public IEnumerable<ElementType> ElementTypes { get; set; }

        public IEnumerable<ElementInfo> RestrictChildrenTo { get; set; }

        public IEnumerable<ElementInfo> RestrictToParentsOf { get; set; }

        public Type DefinitionType { get; set; }

        public IEnumerable<ElementAttributeReference> AttributeReferences { get; set; }
    }

    internal class ElementAttributeReference
    {
        public string ReferenceUrl { get; set; }

        public AttributeInfo AttributeInfo { get; set; }

        public ElementInfo ElementInfo { get; set; }
    }
    
    internal class AttributeInfo
    {
        public bool IsAbstract { get; set; }

        public string Name { get; set; }

        public AttributeValueType AttributeValueType { get; set; }

        public ValidatorInfo ValidatorInfo { get; set; }

        public Type DefinitionType { get; set; }
    }

    internal class ValidatorInfo
    {
        private readonly ValidatorAttribute validatorAttribute;

        public ValidatorInfo(ValidatorAttribute validatorAttribute)
        {
            this.validatorAttribute = validatorAttribute;
        }
    }
}
