using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Persistence.Repositories;

public class TicketRepository : BaseRepository<Ticket>, ITicketRepository {
    public TicketRepository(ProjectManagerDbContext dbContext) : base(dbContext) {
    }

    public Task<bool> IsTicketNameAndDateUnique(Guid ticketProjectId, string ticketName, DateTime dateCreated) {
        // var matches = _dbContext.Tickets.Any(t => t.TicketName.Equals(ticketName) && t.DateCreated.Equals(dateCreated));
        // return Task.FromResult(matches);
        throw new NotImplementedException();
    }
}
