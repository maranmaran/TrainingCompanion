using System;
using Backend.Common;
using MediatR;

namespace Backend.Business_ExerciseType.ExerciseType.Get
{
    public class GetPagedExerciseTypeRequest : IRequest<PagedList<Domain.Entities.ExerciseType.ExerciseType>>
    {
        public Guid UserId { get; set; }
        public PaginationModel PaginationModel { get; set; }
    }
}