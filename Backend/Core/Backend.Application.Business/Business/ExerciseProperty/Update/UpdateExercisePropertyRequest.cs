using System;
using System.Collections.Generic;
using System.Text;
using Backend.Application.Business.Business.ExerciseProperty.Create;
using Backend.Application.Business.Business.ExerciseProperty.UpdateMany;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseProperty.Update
{

    public class UpdateExercisePropertyRequest : IRequest<Domain.Entities.ExerciseType.ExerciseProperty>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
    }
}
