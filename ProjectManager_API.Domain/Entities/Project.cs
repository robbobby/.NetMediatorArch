using ProjectManager_API.Domain.Common;
namespace ProjectManager_API.Domain.Entities; 

public class Project : AuditableEntity {
    public Guid ProjectId { get; set; }
    public User OwnerUser { get; set; }
    public string ProjectName { get; set; }
    public List<UsersInProject> UsersInProjects { get; set; } = new List<UsersInProject>();
    public HashSet<UsersInProject>? UsersInProject { get; set; }
}
