using System;
using System.Linq;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseType.GetAll
{
    public class GetAllExerciseTypeRequest : IRequest<IQueryable<Domain.Entities.ExerciseType.ExerciseType>>
    {
        public Guid UserId { get; set; }
    }
}
