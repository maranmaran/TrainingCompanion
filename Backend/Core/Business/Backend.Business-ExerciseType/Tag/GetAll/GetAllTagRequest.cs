using System;
using System.Linq;
using MediatR;

namespace Backend.Business_ExerciseType.Tag.GetAll
{
    public class GetAllTagRequest : IRequest<IQueryable<Domain.Entities.ExerciseType.Tag>>
    {
        public Guid TagGroupId { get; set; }
        public Guid UserId { get; set; }
    }
}