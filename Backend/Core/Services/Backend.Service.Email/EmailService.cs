using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Email.Interfaces;
using Backend.Service.Email.Models;
using MimeKit;
using Microsoft.Extensions.Hosting;

namespace Backend.Service.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly IWebHostEnvironment _env;

        public EmailService(EmailSettings settings, IWebHostEnvironment env)
        {
            _settings = settings;
            _env = env;
        }

        public async Task SendEmailAsync(EmailMessage emailMessage, CancellationToken cancellationToken)
        {
            try
            {
                var message = ConstructMessage(emailMessage);

                await SendMail(message, cancellationToken);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not send email.", e);
            }
        }

        private async Task SendMail(MimeMessage message, CancellationToken cancellationToken)
        {
            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                if (_env.IsDevelopment())
                {
                    // The third parameter is useSSL (true if the client should make an SSL-wrapped
                    // connection to the server; otherwise, false).
                    await client.ConnectAsync(_settings.Host, _settings.Port, true, cancellationToken);
                }
                else
                {
                    await client.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.Auto, cancellationToken);
                }

                if (_settings.Authenticate)
                    await client.AuthenticateAsync(_settings.Username, _settings.AppPass, cancellationToken);

                await client.SendAsync(message, cancellationToken);

                await client.DisconnectAsync(true, cancellationToken);
            }
        }

        private MimeMessage ConstructMessage(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(emailMessage.To));
            message.From.Add(new MailboxAddress(emailMessage.From));
            message.Subject = emailMessage.Title;
            message.Body = emailMessage.Body;

            return message;
        }
    }
}
