using System.Collections.Generic;
using Backend.Domain.Entities;

namespace Backend.Application.Business.Business.Subusers.GetAllSubusers
{
    public class GetAllSubusersRequestResponse
    {
        public IEnumerable<ApplicationUser> Subusers { get; set; }
    }
}
