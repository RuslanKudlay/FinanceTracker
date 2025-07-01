using System.Net;
using System.Net.Mail;
using BAL.Services.Interfaces;
using DAL.Exceptions;
using Microsoft.Extensions.Configuration;

namespace BAL.Services;

public class SmtpEmailService : IEmailService
{
    private readonly IConfiguration _conf;

    private readonly string _host;
    private readonly int _port;
    private readonly string _userName;
    private readonly string _password;
    private readonly string _fromEmail;
    private readonly bool _enableSsl;
    

    public SmtpEmailService(IConfiguration conf)
    {
        _conf = conf;
        
        _host = _conf.GetSection("SmtpSettings")["Host"];
        _port = int.Parse(_conf.GetSection("SmtpSettings")["Port"]);
        _userName = _conf.GetSection("SmtpSettings")["UserName"];
        _password = _conf.GetSection("SmtpSettings")["Password"];
        _fromEmail = _conf.GetSection("SmtpSettings")["FromEmail"];
        _enableSsl = bool.Parse(_conf.GetSection("SmtpSettings")["EnableSsl"]);
    }

    public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
    {
        try
        {
            using var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_userName, _password),
                EnableSsl = _enableSsl
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
            return true;
        }
        catch (Exception e)
        {
            throw new CustomException(e.Message);
        }
    }
}