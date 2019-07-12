using System;
using Backend.Service.Email;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Email.Interfaces;
using Backend.Service.Email.Models;
using netDumbster.smtp;
using Xunit;

namespace Backend.Core.Service.Tests
{
    public class EmailServiceTests
    {
        private readonly IEmailService _emailService;
        private readonly SimpleSmtpServer _smtpServer;

        // fixture
        public EmailServiceTests()
        {
            var port = (new Random()).Next(50000, 60000);

            var emailSettings = new EmailSettings()
            {
                Host = "localhost",
                Port = port, //25 standard, 465 ssl
                Authenticate = false
            };

            var envMock = new Mock<IHostingEnvironment>();
            _emailService = new EmailService(emailSettings, envMock.Object);

            _smtpServer = SimpleSmtpServer.Start(port);
            _smtpServer.ClearReceivedEmail();

            // integration test
            //var emailMock = new Mock<IEmailService>(MockBehavior.Strict);
            ////emailMock.Setup(x => x.SendEmailAsync(It.IsAny<EmailMessage>(), CancellationToken.None))
            ////    .Returns(Task.CompletedTask);
            //_emailService = emailMock.Object;
        }

        [Fact]
        public async Task SendEmail_Sends()
        {
            var emailMessage = new EmailMessage()
            {
                Body = @"<h1 style=""color: red"">Test body</h1>",
                From = "urh.marko@gmail.com",
                Title = "Test title",
                To = "to@to.com"
            };

            await _emailService.SendEmailAsync(emailMessage, CancellationToken.None);

            Assert.Equal(1, _smtpServer.ReceivedEmailCount);
        }

    }
}
