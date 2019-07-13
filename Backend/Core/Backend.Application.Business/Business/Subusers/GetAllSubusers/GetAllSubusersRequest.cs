using System.Linq;
using Backend.Domain.Entities;
using MediatR;

namespace Backend.Application.Business.Business.Subusers.GetAllSubusers
{
    public class GetAllSubusersRequest : IRequest<IQueryable<ApplicationUser>>
    {
    }
}
