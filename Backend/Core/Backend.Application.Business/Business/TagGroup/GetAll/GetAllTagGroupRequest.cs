using MediatR;
using System;
using System.Linq;

namespace Backend.Application.Business.Business.TagGroup.GetAll
{
    public class GetAllTagGroupRequest : IRequest<IQueryable<Domain.Entities.ExerciseType.TagGroup>>
    {
        public Guid ApplicationUserId { get; set; }
    }
}
