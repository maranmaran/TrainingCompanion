using System;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.Subusers.Commands.Create
{
    public class CreateSubuserCommand : IRequest<CreateSubuserResponse>
    {
        public Guid ParentId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn => DateTime.UtcNow;
        public DateTime LastModified => CreatedOn;
        public AccountStatus AccountStatus => AccountStatus.Waiting;
        public AccountType AccountType => AccountType.Subuser;
    }
}
