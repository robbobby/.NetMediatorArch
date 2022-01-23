using ProjectManager_API.Domain.Common;

namespace ProjectManager_API.Domain.Entities;

public class User {
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public List<UsersInProject> UsersInProjects { get; set; }
    public List<Ticket>? TicketsAssigned { get; set; }
}
