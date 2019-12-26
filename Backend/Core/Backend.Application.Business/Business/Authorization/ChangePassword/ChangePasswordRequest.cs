using MediatR;
using System;

namespace Backend.Application.Business.Business.Authorization.ChangePassword
{
    public class ChangePasswordRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}