using Microsoft.EntityFrameworkCore;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Persistence.Repositories;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository {
    public ProjectRepository(ProjectManagerDbContext dbContext) : base(dbContext) {
    }

    public async Task<Project?> GetProjectsWithTickets(Guid requestProjectId, bool requestIncludeHistory) {
        // return await _dbContext.Projects.FindAsync(requestProjectId);
        return new Project();
    }

    public async Task<List<Project>> GetAllUsersProjects(Guid userId) {
        // return _dbContext.Projects.Where(x => x.UsersAndRoles
            // .Any(y => y.User.UserId == userId)).ToListAsync();
            // return _dbContext.Projects.Where(x => x.OwnerUser.UserId.Equals(userId)).ToListAsync();
            return new List<Project>();
    }
}
  