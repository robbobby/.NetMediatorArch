using ProjectManager_API.Domain.Common;
namespace ProjectManager_API.Domain.Entities; 

public class Ticket : AuditableEntity {
    public Guid TicketId { get; set; }
    public string TicketName { get; set; }
    public TicketState TicketState { get; set; }
    public Guid? UserAssignedId { get; set; }
    public User UserAssigned { get; set; }
    public Guid ProjectId { get; set; }
    public Guid Project { get; set; }
    public string Description { get; set; }
}
