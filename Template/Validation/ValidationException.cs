using System;
using System.Collections.Generic;

namespace Template.Validation
{
    public class ValidationException : Exception
    {
        public readonly IEnumerable<ValidationError> ValidationErrors;

        public ValidationException(IEnumerable<ValidationError> validationErrors) : base("Validation errors occurred")
        {
            ValidationErrors = validationErrors;
        }
    }
}