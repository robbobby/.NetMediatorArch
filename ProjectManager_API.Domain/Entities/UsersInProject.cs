using ProjectManager_API.Domain.Enums;

namespace ProjectManager_API.Domain.Entities;

public class UsersInProject {
    public int UsersInProjectId { get; set; }
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public UserPermissions UserPermissions { get; set; }
}