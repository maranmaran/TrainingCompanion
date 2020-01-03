using Backend.Common;
using MediatR;
using System;

namespace Backend.Application.Business.Business.ExerciseType.Get
{
    public class GetPagedExerciseTypeRequest : IRequest<PagedList<Domain.Entities.ExerciseType.ExerciseType>>
    {
        public Guid UserId { get; set; }
        public PaginationModel PaginationModel { get; set; }
    }
}