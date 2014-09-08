using Coding.Writers;

namespace Coding.Binding
{
    public static class FieldWriterExtensions
    {
        public static FieldWriter IsInternal(this FieldWriter field)
        {
            field.PrimaryAccessModifier = PrimaryAccessModifiers.Internal;
            return field;
        }

        public static FieldWriter IsPrivate(this FieldWriter field)
        {
            field.PrimaryAccessModifier = PrimaryAccessModifiers.Private;
            return field;
        }

        public static FieldWriter IsProtected(this FieldWriter field)
        {
            field.PrimaryAccessModifier = PrimaryAccessModifiers.Protected;
            return field;
        }

        public static FieldWriter IsPublic(this FieldWriter field)
        {
            field.PrimaryAccessModifier = PrimaryAccessModifiers.Public;
            return field;
        }

        public static FieldWriter IsReadonly(this FieldWriter field)
        {
            field.SecondaryAccessModifier = SecondaryAccessModifiers.Readonly;
            return field;
        }

        public static FieldWriter IsStatic(this FieldWriter field)
        {
            field.SecondaryAccessModifier = SecondaryAccessModifiers.Static;
            return field;
        }

        public static FieldWriter IsStaticReadonly(this FieldWriter field)
        {
            field.SecondaryAccessModifier = SecondaryAccessModifiers.StaticReadonly;
            return field;
        }
    }
}