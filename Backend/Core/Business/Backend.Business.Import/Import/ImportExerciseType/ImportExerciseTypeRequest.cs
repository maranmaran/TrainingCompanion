using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Business.Import.Import.ImportExerciseType
{
    public class ImportExerciseTypeRequest : IRequest<ImportExerciseTypeResponse>
    {
        public Guid Userid { get; set; }
        public IFormFile File { get; set; }
    }
}