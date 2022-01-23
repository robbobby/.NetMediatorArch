using ProjectManager_API.Application.Models.Mail;

namespace ProjectManager_API.Application.Interfaces.Infrastructure; 

public interface IEmailService {
    Task<bool> SendEmail(Email email);
}
