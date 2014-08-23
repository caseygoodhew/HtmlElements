using System;
using System.Linq.Expressions;

namespace HtmlElements
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class DoNotNest : Attribute { }

    [AttributeUsage(AttributeTargets.Class)]
    internal class RestrictToParent : Attribute
    {
        public readonly Type ParentType;

        public RestrictToParent(Type type)
        {
            ParentType = type;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    internal class RestrictToChild : Attribute
    {
        public readonly Type ChildType;

        public RestrictToChild(Type type)
        {
            ChildType = type;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    internal class AttributeName : Attribute
    {
        public readonly string Name;

        public AttributeName(string name)
        {
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class AppliesToElement : Attribute
    {
        public readonly Type ElementType;

        public readonly string ReferenceUrl;

        public AppliesToElement(Type type, string referenceUrl)
        {
            ElementType = type;
            ReferenceUrl = referenceUrl;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    internal class AppliesToElementWithoutAttach : AppliesToElement
    {
        public readonly object ValueToSet;

        public AppliesToElementWithoutAttach(Type type, object valueToSet, string referenceUrl) : base(type, referenceUrl)
        {
            ValueToSet = valueToSet;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class Reference : Attribute
    {
        public readonly string _url;

        // can be made public - set to private for testing
        private Reference(string url)
        {
            _url = url;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    internal class Validator : Attribute
    {
        public readonly Type AttributeValidatorType;

        public Validator(Type attributeValidatorType) 
        {
            if (!typeof(IAttributeValidator).IsAssignableFrom(attributeValidatorType))
            {
                throw new ArgumentException("Type not assignable from IAttributeValidator", "attributeValidatorType");
            }

            AttributeValidatorType = attributeValidatorType;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    internal class ValidatorOption : Attribute
    {
        public readonly string Key;

        public readonly object Value;

        public ValidatorOption(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    internal class ValidatorForEnum : Attribute
    {
        public readonly Type EnumType;

        public ValidatorForEnum(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type is not an Enum", "enumType");
            }

            EnumType = enumType;
        }
    }
}
