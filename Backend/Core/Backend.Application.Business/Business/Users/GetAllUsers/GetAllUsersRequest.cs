using System.Linq;
using Backend.Domain.Entities;
using MediatR;

namespace Backend.Application.Business.Business.Users.GetAllUsers
{
    public class GetAllUsersRequest : IRequest<IQueryable<ApplicationUser>>
    {
    }
}
