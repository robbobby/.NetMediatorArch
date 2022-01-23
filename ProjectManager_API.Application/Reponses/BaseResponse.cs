using FluentValidation.Results;

namespace ProjectManager_API.Application.Reponses; 

public class BaseResponse {
    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> ValidationErrors { get; set; }
    public BaseResponse() {
        Success = true;
    }

    public BaseResponse(string message = null) {
        Success = true;
        message = message;
    }

    public BaseResponse(string message, bool success) {
        Success = success;
        Message = message;
    }
    
    public void SetValidationErrors(ValidationResult validationResult) {
        ValidationErrors = new List<string>();
        foreach (var resultError in validationResult.Errors) {
            ValidationErrors.Add(resultError.ErrorMessage);
        }
    }
}
