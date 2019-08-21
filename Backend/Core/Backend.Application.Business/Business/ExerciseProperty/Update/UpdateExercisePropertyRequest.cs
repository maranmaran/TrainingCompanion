using MediatR;
using System;

namespace Backend.Application.Business.Business.ExerciseProperty.Update
{

    public class UpdateExercisePropertyRequest : IRequest<Domain.Entities.ExerciseType.ExerciseProperty>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
    }

}
