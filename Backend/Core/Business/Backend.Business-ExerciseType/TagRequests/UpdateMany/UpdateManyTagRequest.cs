using Backend.Domain.Entities.Exercises;
using MediatR;
using System.Collections.Generic;

namespace Backend.Business.Exercises.TagRequests.UpdateMany
{
    public class UpdateManyTagRequest : IRequest<Unit>
    {
        public IEnumerable<Tag> ExerciseProperties { get; set; }
    }
}