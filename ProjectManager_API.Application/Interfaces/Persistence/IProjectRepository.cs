using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Domain.Entities;
namespace ProjectManager_API.Application.Contracts.Persistence; 

public interface IProjectRepository : IAsyncRepository<Project> {

    Task<Project?> GetProjectsWithTickets(Guid requestProjectId, bool requestIncludeHistory);
    Task<List<Project>> GetAllUsersProjects(Guid userId);
}