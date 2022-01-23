using Bogus;
using Microsoft.EntityFrameworkCore;
using ProjectManager_API.Domain.Common;
using ProjectManager_API.Domain.Entities;

namespace ProjectManager_API.Persistence;

public class ProjectManagerDbContext : DbContext {
    protected ProjectManagerDbContext() {
    }

    public ProjectManagerDbContext(DbContextOptions<ProjectManagerDbContext> options) : base(options) {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<UsersInProject> UsersInProjects { get; set; } 
    
    // public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectManagerDbContext).Assembly);
    SeedData.Seed(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new()) {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            switch (entry.State) {
                case EntityState.Added:
                    entry.Entity.DateCreated = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        return base.SaveChangesAsync(cancellationToken);
    }
}