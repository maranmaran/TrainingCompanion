using System;
using System.Collections.Generic;
using MediatR;

namespace Backend.Application.Business.Business.ExerciseProperty.UpdateMany
{
    public class UpdateExercisePropertyTypeRequest : IRequest<Domain.Entities.ExerciseType.ExercisePropertyType>
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public string HexColor { get; set; }
    }
}
