using System;
using System.Linq;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseProperty.GetAll
{
    public class GetAllExercisePropertyTypeRequest : IRequest<IQueryable<Domain.Entities.ExerciseType.ExercisePropertyType>>
    {
        public Guid ApplicationUserId { get; set; }
    }
}
