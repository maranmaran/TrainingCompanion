using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Enum;
using MediatR;
using System;
using System.Linq;

namespace Backend.Application.Business.Business.ExerciseTypeProperties.GetAll
{
    public class GetAllExerciseTypePropertyRequest : IRequest<IQueryable<ExerciseTypeProperty>>
    {
        public ExerciseTypePropertyType Type { get; set; }
        public Guid UserId { get; set; }
    }
}
