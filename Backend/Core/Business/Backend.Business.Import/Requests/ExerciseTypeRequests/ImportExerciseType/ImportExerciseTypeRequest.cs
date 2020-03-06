using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Business.Import.Requests.ExerciseTypeRequests.ImportExerciseType
{
    public class ImportExerciseTypeRequest : IRequest<ImportExerciseTypeResponse>
    {
        public Guid Userid { get; set; }
        public IFormFile File { get; set; }
    }
}