using MediatR;
using System;
using System.Linq;

namespace Backend.Application.Business.Business.Tag.GetAll
{
    public class GetAllTagRequest : IRequest<IQueryable<Domain.Entities.ExerciseType.Tag>>
    {
        public Guid TagGroupId { get; set; }
        public Guid UserId { get; set; }
    }
}
