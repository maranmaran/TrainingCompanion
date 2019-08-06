using System.Linq;
using Backend.Domain.Entities;
using MediatR;

namespace Backend.Application.Business.Business.Coaches.GetAllCoaches
{
    public class GetAllCoachsRequest : IRequest<IQueryable<Coach>>
    {
    }
}
