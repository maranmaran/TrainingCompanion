using System;
using System.Linq;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseProperty.GetAll
{
    public class GetAllExercisePropertyRequest : IRequest<IQueryable<Domain.Entities.ExerciseType.ExerciseProperty>>
    {
        public Guid ExercisePropertyTypeId { get; set; }
        public Guid UserId { get; set; }
    }
}
