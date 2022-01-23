using Microsoft.EntityFrameworkCore;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Application.Interfaces.Persistence;

namespace ProjectManager_API.Persistence.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class {
    protected readonly ProjectManagerDbContext _dbContext;

    public BaseRepository(ProjectManagerDbContext dbContext) {
        _dbContext = dbContext;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id) {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAllAsListAsync() {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity) {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity) {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity) {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}
