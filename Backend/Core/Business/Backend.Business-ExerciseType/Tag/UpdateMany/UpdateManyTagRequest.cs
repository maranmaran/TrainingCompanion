﻿using MediatR;
using System.Collections.Generic;

namespace Backend.Business.ExerciseType.Tag.UpdateMany
{
    public class UpdateManyTagRequest : IRequest<Unit>
    {
        public IEnumerable<Domain.Entities.ExerciseType.Tag> ExerciseProperties { get; set; }
    }
}