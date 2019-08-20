using System;
using MediatR;

namespace Backend.Application.Business.Business.ExercisePropertyType.Update
{
    public class UpdateExercisePropertyTypeRequest : IRequest<Domain.Entities.ExerciseType.ExercisePropertyType>
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public string HexColor { get; set; }
    }
}
