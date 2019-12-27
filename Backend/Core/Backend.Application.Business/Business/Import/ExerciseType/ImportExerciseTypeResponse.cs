using Backend.Common;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Application.Business.Business.Import.ExerciseType
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

            if (errors != null && errors.Any())
                Success = false;
        }
    }
}
