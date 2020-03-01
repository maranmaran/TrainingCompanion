using MediatR;
using System;
using System.Linq;

namespace Backend.Business.ExerciseType.TagGroup.GetAll
{
    public class GetAllTagGroupRequest : IRequest<IQueryable<Domain.Entities.ExerciseType.TagGroup>>
    {
        public Guid ApplicationUserId { get; set; }
    }
}