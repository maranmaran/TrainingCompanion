﻿using Backend.Domain.Entities.Exercises;
using MediatR;
using System;
using System.Collections.Generic;

namespace Backend.Business.Exercises.ExerciseTypeRequests.GetAll
{
    public class GetAllExerciseTypeRequest : IRequest<IEnumerable<ExerciseType>>
    {
        public Guid UserId { get; set; }
    }
}