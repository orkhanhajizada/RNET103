using System.Net;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Services;

namespace NotificationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailsController : ControllerBase
{
    private readonly IMailService _mailService;

    public MailsController(IMailService mailService)
    {
        _mailService = mailService;
    }

    [HttpPost]
    public async Task<IActionResult> SendMail()
    {
        try
        {
            await _mailService.SendEmailAsync("orkhanmh@code.edu.az", "test mail", "Test mail body");
            return Ok(HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return Ok(HttpStatusCode.BadRequest);

        }
    }
}


public class MailConfiguration
{
    public string Server { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool EnableSsl { get; set; }
    public string From { get; set; }
}