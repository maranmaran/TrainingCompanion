using System;
using System.Linq;
using Backend.Domain.Entities.Exercises;
using MediatR;

namespace Backend.Business.Exercises.TagGroupRequests.GetAll
{
    public class GetAllTagGroupRequest : IRequest<IQueryable<TagGroup>>
    {
        public Guid ApplicationUserId { get; set; }
    }
}