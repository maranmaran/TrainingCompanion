using System.Collections.Generic;
using Backend.Domain.Entities.Exercises;
using MediatR;

namespace Backend.Business.Exercises.TagRequests.UpdateMany
{
    public class UpdateManyTagRequest : IRequest<Unit>
    {
        public IEnumerable<Tag> ExerciseProperties { get; set; }
    }
}