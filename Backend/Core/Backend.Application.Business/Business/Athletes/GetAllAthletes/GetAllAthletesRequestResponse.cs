using System.Collections.Generic;
using Backend.Domain.Entities;

namespace Backend.Application.Business.Business.Athletes.GetAllAthletes
{
    public class GetAllAthletesRequestResponse
    {
        public IEnumerable<ApplicationUser> Athletes { get; set; }
    }
}
