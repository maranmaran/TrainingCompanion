using System;
using System.Linq;
using MediatR;

namespace Backend.Business_ExerciseType.TagGroup.GetAll
{
    public class GetAllTagGroupRequest : IRequest<IQueryable<Domain.Entities.ExerciseType.TagGroup>>
    {
        public Guid ApplicationUserId { get; set; }
    }
}