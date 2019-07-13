using System;
using Backend.Domain.Entities;
using Backend.Domain.Enum;

namespace Backend.Application.Business.Business.Subusers.CreateSubuser
{
    public class CreateSubuserRequestResponse
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
