using MediatR;
using ProjectManager_API.Application.Reponses;

namespace ProjectManager_API.Application.Features.ProjectFeatures.Commands;

public class CreateProjectCommand : IRequest<CreateProjectCommandResponse> {
    public Guid OwnerUser { get; set; }
    public Guid ProjectId { get; set; }
    public string ProjectName { get; set; }
    public List<Guid>? TicketGuids { get; set; }
    public List<UserAndRolesGuidDto> UserGuidAndRoles { get; set; }
}