using Backend.Domain.Entities;
using Backend.Domain.Enum;
using System;

namespace Backend.Application.Business.Business.Subusers.Commands.Create
{
    public class CreateSubuserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }
        public AccountStatus AccountStatus => AccountStatus.Waiting;
        public AccountType AccountType => AccountType.Subuser;
        public Guid ParentId { get; set; }
        public ApplicationUser Parent { get; set; }
    }
}
