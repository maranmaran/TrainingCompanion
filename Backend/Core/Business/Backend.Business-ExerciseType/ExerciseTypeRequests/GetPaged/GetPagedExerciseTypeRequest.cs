﻿using Backend.Common;
using Backend.Domain.Entities.Exercises;
using MediatR;
using System;

namespace Backend.Business.Exercises.ExerciseTypeRequests.GetPaged
{
    public class GetPagedExerciseTypeRequest : IRequest<PagedList<ExerciseType>>
    {
        public Guid UserId { get; set; }
        public PaginationModel PaginationModel { get; set; }
    }
}