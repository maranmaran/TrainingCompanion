using System.Collections.Generic;
using System.Linq;
using Backend.Common;

namespace Backend.Application.Business.Business.Import.ImportExerciseType
{
    public class ImportExerciseTypeResponse
    {
        public bool Success { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }

        public ImportExerciseTypeResponse(bool success)
        {
            Success = success;
        }

        public ImportExerciseTypeResponse(IEnumerable<ValidationError> errors)
        {
            Errors = errors;

            Success = errors == null || !errors.Any();
        }
    }
}
