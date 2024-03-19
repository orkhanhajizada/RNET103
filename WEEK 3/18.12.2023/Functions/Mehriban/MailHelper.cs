using System.Net.Mail;

namespace Mehriban;

public class MailHelper
{
    public bool SendMail(string subject, string body,string cc, string to, string from, bool isHtml)
    {
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.Credentials = new System.Net.NetworkCredential(from, "Salam123");
        smtpClient.EnableSsl = true;
        MailMessage message = new MailMessage()
        {
            From = new MailAddress("from"),
            Subject = subject,
            Body = body,
        };
        message.To.Add(to);
        message.CC.Add(cc);
        message.IsBodyHtml = isHtml;

        try
        {
            smtpClient.Send(message);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}