using MailKit.Net.Smtp;
using MimeKit;
using NotificationService.Controllers;

namespace NotificationService.Services;

public interface IMailService
{
    Task SendEmailAsync(string to, string subject, string body);
}


public  class MailService : IMailService
{
    private readonly IConfiguration _configuration;
    
    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        
        var configuration = _configuration.GetSection("SmtpSettings").Get<MailConfiguration>();
        
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(configuration.UserName, configuration.From));
        emailMessage.To.Add(new MailboxAddress("", to));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart("html")
        {
            Text = body
        };
        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("localhost", 587, false);
            await client.AuthenticateAsync("admin", "admin");
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}