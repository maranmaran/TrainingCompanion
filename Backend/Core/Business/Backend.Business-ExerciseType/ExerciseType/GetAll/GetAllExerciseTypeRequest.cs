using MediatR;
using System;
using System.Linq;

namespace Backend.Business.ExerciseType.ExerciseType.GetAll
{
    public class GetAllExerciseTypeRequest : IRequest<IQueryable<Domain.Entities.ExerciseType.ExerciseType>>
    {
        public Guid UserId { get; set; }
    }
}