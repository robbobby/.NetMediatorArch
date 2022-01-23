using ProjectManager_API.Application.Reponses;
using ProjectManager_API.Domain.Enums;

namespace ProjectManager_API.Application.Features.ProjectFeatures.Commands;

public class UserAndRolesGuidDto {
    public UserPermissions UserPermissions { get; set; }
    public Guid ProjectId { get; set; }
}

public class CreateProjectDto {
}


public class CreateProjectCommandResponse : BaseResponse {
    public CreateProjectDto Project { get; set; }
}