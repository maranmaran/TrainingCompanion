using System;
using System.Linq;
using MediatR;

namespace Backend.Application.Business.Business.ExercisePropertyType.GetAll
{
    public class GetAllExercisePropertyTypeRequest : IRequest<IQueryable<Domain.Entities.ExerciseType.ExercisePropertyType>>
    {
        public Guid ApplicationUserId { get; set; }
    }
}
