using System;
using Coding.Writers;

namespace Coding.Binding
{
    public static class PropertyWriterExtensions
    {
        public static PropertyWriter IsInternal(this PropertyWriter property, Property? target = null)
        {
            return SetAccessor(property, PrimaryAccessModifiers.Internal, target);
        }

        public static PropertyWriter IsPrivate(this PropertyWriter property, Property? target = null)
        {
            return SetAccessor(property, PrimaryAccessModifiers.Private, target);
        }

        public static PropertyWriter IsProtected(this PropertyWriter property, Property? target = null)
        {
            return SetAccessor(property, PrimaryAccessModifiers.Protected, target);
        }

        public static PropertyWriter IsPublic(this PropertyWriter property, Property? target = null)
        {
            return SetAccessor(property, PrimaryAccessModifiers.Public, target);
        }

        public static PropertyWriter IsAbstract(this PropertyWriter property, Property whichProperty = Property.GetterSetter)
        {
            property.SecondaryAccessModifier = SecondaryAccessModifiers.Abstract;
            return ToggleHasGetterSetter(property, whichProperty);
        }

        public static PropertyWriter IsVirtual(this PropertyWriter property, Property whichProperty = Property.GetterSetter)
        {
            property.SecondaryAccessModifier = SecondaryAccessModifiers.Virtual;
            return ToggleHasGetterSetter(property, whichProperty);
        }

        public static PropertyWriter IsOverride(this PropertyWriter property, Property whichProperty = Property.GetterSetter)
        {
            property.SecondaryAccessModifier = SecondaryAccessModifiers.Override;
            return ToggleHasGetterSetter(property, whichProperty);
        }

        public static PropertyWriter IsStatic(this PropertyWriter property)
        {
            property.SecondaryAccessModifier = SecondaryAccessModifiers.Static;
            return property;
        }

        private static PropertyWriter SetAccessor(PropertyWriter property, PrimaryAccessModifiers modifier, Property? target)
        {
            switch (target)
            {
                case Property.Getter:
                    property.GetterAccessModifier = modifier;
                    break;
                case Property.Setter:
                    property.SetterAccessModifier = modifier;
                    break;
                case Property.GetterSetter:
                    property.GetterAccessModifier = modifier;
                    property.SetterAccessModifier = modifier;
                    break;
                case null:
                    property.PrimaryAccessModifier = modifier;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("target");
            }

            return property;
        }

        private static PropertyWriter ToggleHasGetterSetter(PropertyWriter property, Property whichProperty)
        {
            switch (whichProperty)
            {
                case Property.Getter:
                    property.HasGetter = true;
                    property.HasSetter = false;
                    break;
                case Property.Setter:
                    property.HasGetter = false;
                    property.HasSetter = true;
                    break;
                case Property.GetterSetter:
                    property.HasGetter = true;
                    property.HasSetter = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("whichProperty");
            }

            return property;
        }
    }
}