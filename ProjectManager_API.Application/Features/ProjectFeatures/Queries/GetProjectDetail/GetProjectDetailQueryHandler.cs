using AutoMapper;
using MediatR;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Features.ProjectFeatures.Queries.GetProjectDetail;

public class GetProjectDetailQuery : IRequest<List<ProjectDetailedVm>> {
    public bool IncludeCompleteTickets { get; set; }
    public Guid ProjectId { get; set; }
}

public class GetProjectDetailQueryHandler : IRequestHandler<GetProjectDetailQuery, List<ProjectDetailedVm>> {

    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public GetProjectDetailQueryHandler(IProjectRepository projectRepository, IMapper mapper) {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<List<ProjectDetailedVm>> Handle(GetProjectDetailQuery request, CancellationToken cancellationToken) {
        var listOfProjects = await _projectRepository.GetProjectsWithTickets(request.ProjectId, request.IncludeCompleteTickets);
        return _mapper.Map<List<ProjectDetailedVm>>(listOfProjects);
    }
}
