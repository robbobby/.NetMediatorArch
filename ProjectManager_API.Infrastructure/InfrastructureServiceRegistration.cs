using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager_API.Application.Interfaces.Infrastructure;
using ProjectManager_API.Application.Models.Mail;

namespace ProjectManager_API.Infrastructure; 

public static class InfrastructureServiceRegistration {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}
