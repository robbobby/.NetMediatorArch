using FluentValidation.Results;
// using ProjectManager_API.Application.Features.ProjectFeatures.Commands;

namespace ProjectManager_API.Application.Exceptions;

public class ValidationException : ApplicationException {
    public List<string> ValidationErrors { get; set; }

    public ValidationException(ValidationResult validationResult) {
        ValidationErrors = new List<string>();
        foreach (ValidationFailure validationResultError in validationResult.Errors) {
            ValidationErrors.Add(validationResultError.ErrorMessage);
        }
    }
}