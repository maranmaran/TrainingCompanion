using System;
using MediatR;

namespace Backend.Business.Authorization.Authorization.ChangePassword
{
    public class ChangePasswordRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}