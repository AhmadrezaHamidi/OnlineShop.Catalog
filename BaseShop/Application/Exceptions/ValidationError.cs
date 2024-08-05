using System;
namespace Application.Exceptions
{
    public sealed record ValidationError(string PropertName, string ErrorMessage);

    public sealed class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationError> Errors { get; }
    }
}

