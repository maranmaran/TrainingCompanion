using System;
using MediatR;

namespace Backend.Application.Business.Business.ExercisePropertyType.Create
{
    public class CreateExercisePropertyTypeRequest : IRequest<Domain.Entities.ExerciseType.ExercisePropertyType>
    {
        public Guid ApplicationUserId { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }
        public string HexColor { get; set; }
    }
}
