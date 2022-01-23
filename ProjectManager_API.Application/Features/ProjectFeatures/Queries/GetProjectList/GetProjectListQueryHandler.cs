using AutoMapper;
using MediatR;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Features.ProjectFeatures.Queries.GetProjectList;

public class GetProjectListQuery : IRequest<List<ProjectListVm>> {
}

public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, List<ProjectListVm>> {

    private readonly IAsyncRepository<Project> _eventRepository;
    private readonly IMapper _mapper;

    public GetProjectListQueryHandler(IAsyncRepository<Project> eventRepository, IMapper mapper) {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<List<ProjectListVm>> Handle(GetProjectListQuery request, CancellationToken cancellationToken) {
        var allProjects = (await _eventRepository.GetAllAsListAsync()).OrderBy(x => x.DateCreated);
        return _mapper.Map<List<ProjectListVm>>(allProjects);
    }
}
