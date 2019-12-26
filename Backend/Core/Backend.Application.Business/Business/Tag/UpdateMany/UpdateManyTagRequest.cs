using MediatR;
using System.Collections.Generic;

namespace Backend.Application.Business.Business.Tag.UpdateMany
{
    public class UpdateManyTagRequest : IRequest<Unit>
    {
        public IEnumerable<Domain.Entities.ExerciseType.Tag> ExerciseProperties { get; set; }
    }
}