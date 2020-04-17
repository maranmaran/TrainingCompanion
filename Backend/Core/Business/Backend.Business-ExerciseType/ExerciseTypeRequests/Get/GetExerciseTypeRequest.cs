using Backend.Domain.Entities.Exercises;
using MediatR;
using System;

namespace Backend.Business.Exercises.ExerciseTypeRequests.Get
{
    public class GetExerciseTypeRequest : IRequest<ExerciseType>
    {
        public Guid Id { get; set; }

        public GetExerciseTypeRequest(Guid id)
        {
            Id = id;
        }
    }
}
