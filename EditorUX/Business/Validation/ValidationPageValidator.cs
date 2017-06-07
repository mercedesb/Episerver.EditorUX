using EditorUX.Models.Pages;
using EPiServer.Validation;
using System;
using System.Collections.Generic;

namespace EditorUX.Business.Validation
{
    public class ValidationPageValidator : IValidate<ValidationPage>
    {
        public virtual IEnumerable<ValidationError> Validate(ValidationPage page)
        {
            // Validation checks would go here
            // one error per property
            int rand = new Random().Next(3);
            switch (rand)
            {
                case (0):
                    return new[] {
                        new ValidationError()
                        {
                            ErrorMessage = "Randomly generated error. Try again.",
                            Severity = ValidationErrorSeverity.Error,
                            PropertyName = "Name",
                            ValidationType = ValidationErrorType.Unspecified
                        } };
                case (1):
                    return new[] {
                        new ValidationError()
                        {
                            ErrorMessage = "Randomly generated warning.",
                            Severity = ValidationErrorSeverity.Warning,
                            PropertyName = "Name",
                            ValidationType = ValidationErrorType.Unspecified
                        } };
                case (2):
                default:
                    return new[] {
                        new ValidationError()
                        {
                            ErrorMessage = "Randomly generated validation info.",
                            Severity = ValidationErrorSeverity.Info,
                            PropertyName = "Name",
                            ValidationType = ValidationErrorType.Unspecified
                        } };
            }
        }
    }
}
