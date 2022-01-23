namespace ProjectManager_API.Application.Features.TicketFeatures.Queries.GetTicketList; 

public class TicketListVm {
    public Guid TicketId { get; set; }
    public string TicketName { get; set; }
    public TicketState TicketState { get; set; }
}
