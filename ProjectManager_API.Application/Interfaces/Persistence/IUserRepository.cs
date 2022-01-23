using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Application.Interfaces.Persistence; 

public interface IUserRepository : IAsyncRepository<User> {
    
}