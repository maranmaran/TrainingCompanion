﻿using Backend.Library.Email.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Library.Email.Interfaces
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