namespace TheGoal.Programmed
{
    public class ValidationError
    {
        public readonly AttributeInstance AttributeInstance;

        public readonly string Message;

        public ValidationError(AttributeInstance attributeInstance, string message)
        {
            AttributeInstance = attributeInstance;
            Message = message;
        }

        public override string ToString()
        {
            return string.Format(
                @"[{0}][{1}] : {2}",
                AttributeInstance.GetName(),
                AttributeInstance.GetValue(),
                Message);
        }
    }
}