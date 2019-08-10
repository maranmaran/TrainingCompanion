using System.Net.Mail;
using Backend.Service.Email.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Service.Email.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// Sends email
        /// </summary>
        /// <param name="emailMessage"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SendEmailAsync(EmailMessage emailMessage, CancellationToken cancellationToken);
    }
}
