using Backend.Common;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Business.Import.Import.ImportExerciseType
{
    public class ImportExerciseTypeResponse
    {
        public bool Success { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }

        public ImportExerciseTypeResponse()
        {

        }

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
