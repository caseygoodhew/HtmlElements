using System;
using System.Collections.Generic;

namespace TheGoal.Programmed
{
    public class AttributeValidationException : Exception
    {
        public readonly IEnumerable<ValidationError> ValidationErrors;

        public AttributeValidationException(IEnumerable<ValidationError> validationErrors) : base("Validation errors occurred")
        {
            ValidationErrors = validationErrors;
        }
    }
}