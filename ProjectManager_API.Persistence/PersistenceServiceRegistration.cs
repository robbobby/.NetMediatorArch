using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager_API.Application.Contracts.Persistence;
using ProjectManager_API.Application.Interfaces.Persistence;
using ProjectManager_API.Persistence.Repositories;

namespace ProjectManager_API.Persistence; 

public static class PersistenceServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        var sqlServerVersion = new MySqlServerVersion("8.0.27-mysql");
        services.AddDbContext<ProjectManagerDbContext>(options => options.UseMySql(configuration.GetConnectionString("ProjectManagerConnectionString"), sqlServerVersion));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
