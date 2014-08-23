using TheGoal.Programmed;

namespace TheGoal.Generated
{
    public class ClassAttribute : ElementAttribute
    {
        public ClassAttribute() : base("class")
        {
        }

        public override AttributeValidator GetValidator()
        {
            return GetValidator<ClassAttributeValidator>();
        }
    }
}