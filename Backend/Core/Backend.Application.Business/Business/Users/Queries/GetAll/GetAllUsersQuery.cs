using Backend.Domain.Entities;
using MediatR;
using System.Linq;

namespace Backend.Application.Business.Business.Users.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<IQueryable<ApplicationUser>>
    {
    }
}
