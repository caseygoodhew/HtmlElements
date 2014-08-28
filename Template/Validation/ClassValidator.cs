namespace Template.Validation
{
    public class ClassValidator : RegexValidator
    {
        public ClassValidator()
            : base("^-?[_a-zA-Z]+[_a-zA-Z0-9-]*$", @"""{0}"" is an invalid class value")
        {
        }
    }
}