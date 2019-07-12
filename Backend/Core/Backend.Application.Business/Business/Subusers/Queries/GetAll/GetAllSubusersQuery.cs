using System.Linq;
using Backend.Domain.Entities;
using MediatR;

namespace Backend.Application.Business.Business.Subusers.Queries.GetAll
{
    public class GetAllSubusersQuery : IRequest<IQueryable<ApplicationUser>>
    {
    }
}
