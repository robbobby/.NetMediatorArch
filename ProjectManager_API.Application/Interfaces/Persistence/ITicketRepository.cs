using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Interfaces.Persistence; 

public interface ITicketRepository : IAsyncRepository<Ticket> {

    Task<bool> IsTicketNameAndDateUnique(Guid ticketProjectId, string ticketName, DateTime dateCreated);
}