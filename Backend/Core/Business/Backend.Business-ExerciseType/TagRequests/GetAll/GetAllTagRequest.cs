using Backend.Domain.Entities.Exercises;
using MediatR;
using System;
using System.Linq;

namespace Backend.Business.Exercises.TagRequests.GetAll
{
    public class GetAllTagRequest : IRequest<IQueryable<Tag>>
    {
        public Guid TagGroupId { get; set; }
        public Guid UserId { get; set; }
    }
}