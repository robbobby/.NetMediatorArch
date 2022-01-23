using System.Net;
using Microsoft.Extensions.Options;
using ProjectManager_API.Application.Interfaces.Infrastructure;
using ProjectManager_API.Application.Models.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ProjectManager_API.Infrastructure;

public class EmailService : IEmailService {

    public EmailSettings EmailSettings { get; private set; }

    public EmailService(IOptions<EmailSettings> mailSettings) {
        EmailSettings = mailSettings.Value;
    }

    public async Task<bool> SendEmail(Email email) {
        var client = new SendGridClient(EmailSettings.ApiKey);

        var from = new EmailAddress() {
            Email = EmailSettings.FromAddress,
            Name = EmailSettings.FromName
        };

        var sendGridMessage = MailHelper.CreateSingleEmail(from, new EmailAddress(email.To), email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(sendGridMessage);
        if (response.StatusCode is HttpStatusCode.Accepted or HttpStatusCode.OK)
            return true;

        return false;
    }
}
