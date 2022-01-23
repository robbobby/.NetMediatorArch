using AutoMapper;
using FluentValidation.Results;
using MediatR;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Features.ProjectFeatures.Commands;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectCommandResponse> {
    private IProjectRepository _projectRepository;
    private IMapper _mapper;

    public CreateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper) {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<CreateProjectCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken) {
        CreateProjectCommandResponse response = new();
        CreateProjectCommandValidator validator = new();
        ValidationResult? validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0) {
            response.Success = false;
            response.SetValidationErrors(validationResult);
        }

        if (response.Success) {
            var project = new Project() {
                ProjectName = request.ProjectName
            };

            project = await _projectRepository.AddAsync(project);
            response.Project = _mapper.Map<CreateProjectDto>(project);
        }

        return response;
    }
}
