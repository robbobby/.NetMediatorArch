using FluentValidation;

namespace ProjectManager_API.Application.Features.ProjectFeatures.Commands;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand> {
    public CreateProjectCommandValidator() {

    }
}
