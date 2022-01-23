using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository {
    public UserRepository(ProjectManagerDbContext dbContext) : base(dbContext) {
    }
}
