using System;
using System.Linq;
using MediatR;

namespace Backend.Business_ExerciseType.ExerciseType.GetAll
{
    public class GetAllExerciseTypeRequest : IRequest<IQueryable<Domain.Entities.ExerciseType.ExerciseType>>
    {
        public Guid UserId { get; set; }
    }
}