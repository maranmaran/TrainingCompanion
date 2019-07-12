using System.Collections.Generic;
using Backend.Domain.Entities;

namespace Backend.Application.Business.Business.Subusers.Queries.GetAll
{
    public class GetAllSubusersResponse
    {
        public IEnumerable<ApplicationUser> Subusers { get; set; }
    }
}
