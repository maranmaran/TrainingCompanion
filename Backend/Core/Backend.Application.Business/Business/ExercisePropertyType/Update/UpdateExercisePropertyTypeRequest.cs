using System;
using MediatR;

namespace Backend.Application.Business.Business.ExercisePropertyType.Update
{
    public class UpdateExercisePropertyTypeRequest : IRequest<Domain.Entities.ExerciseType.ExercisePropertyType>
    {
        public Domain.Entities.ExerciseType.ExercisePropertyType ExercisePropertyType { get; set; }

        public UpdateExercisePropertyTypeRequest(Domain.Entities.ExerciseType.ExercisePropertyType exercisePropertyType)
        {
            ExercisePropertyType = exercisePropertyType;
        }
    }
}
