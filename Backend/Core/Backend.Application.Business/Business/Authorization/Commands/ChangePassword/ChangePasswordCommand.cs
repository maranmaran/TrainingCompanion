using System;
using MediatR;

namespace Backend.Application.Business.Business.Authorization.Commands.ChangePassword
{
    public class ChangePasswordCommand: IRequest
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
