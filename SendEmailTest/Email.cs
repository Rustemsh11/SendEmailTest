﻿using MailKit.Net.Smtp;
using MimeKit;
using SendEmailTest.Models;


namespace SendEmailTest
{
    public class Email
    {
        private readonly ILogger<Email> _logger;
        private readonly IConfiguration _configuration;
        public Email(ILogger<Email> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public void CreateEmail(EmailData emailData)
        {
            try
            {

                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(emailData.CompanyName, emailData.Sender));
                message.To.Add(new MailboxAddress("", emailData.Recipient));
                message.Subject = EmailData.Title;
                var bodyBuilder = new BodyBuilder() { HtmlBody = $"<div>{emailData.Text}</div>" };
                if (emailData.Attachment != null && emailData.Attachment.Any())
                {
                    
                        bodyBuilder.Attachments.Add(emailData.Attachment);
                    
                }
                message.Body = bodyBuilder.ToMessageBody();
                using (SmtpClient client = new SmtpClient())
                {
                    
                    client.Connect("smtp.yandex.ru", 465, true);
                    client.Authenticate("rustemsh11@yandex.ru", "vaayzmsgogztikng");
                    client.Send(message);
                    client.Disconnect(true);
                    _logger.LogInformation("Success");
                }
            }
            catch (Exception exeption)
            {

                _logger.LogInformation(exeption.GetBaseException().Message);
            }
        }
    }
}
