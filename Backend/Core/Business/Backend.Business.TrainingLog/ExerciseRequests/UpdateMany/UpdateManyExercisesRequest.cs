﻿using MediatR;
using System.Collections.Generic;

namespace Backend.Business.TrainingLog.ExerciseRequests.UpdateMany
{
    public class UpdateManyExercisesRequest : IRequest<Unit>
    {
        public IEnumerable<Domain.Entities.TrainingLog.Exercise> Exercises { get; set; }

        public UpdateManyExercisesRequest(IEnumerable<Domain.Entities.TrainingLog.Exercise> data)
        {
            Exercises = data;
        }
    }
}