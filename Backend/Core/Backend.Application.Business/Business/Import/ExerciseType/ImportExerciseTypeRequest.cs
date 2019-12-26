using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace Backend.Application.Business.Business.Import.ExerciseType
{
    public class ImportExerciseTypeRequest : IRequest
    {
        public Guid Userid { get; set; }
        public IFormFile File { get; set; }
    }
}