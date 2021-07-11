using Backend.Domain.Entities.Exercises;
using MediatR;
using System;
using System.Linq;

namespace Backend.Business.Exercises.TagGroupRequests.GetAll
{
    public class GetAllTagGroupRequest : IRequest<IQueryable<TagGroup>>
    {
        public Guid ApplicationUserId { get; set; }
    }
}