using System.Collections.Generic;
using System.Linq;
using System.Net;
using Backend.Common;

namespace Backend.Business.Import.ImportExerciseType
{
    public class ImportExerciseTypeResponse
    {
        public bool Success { get; set; }
        public List<ValidationError> _errors { get; set; } = new List<ValidationError>();

        public ImportExerciseTypeResponse()
        {
        }

        public ImportExerciseTypeResponse(bool success)
        {
            Success = success;
        }

        public ImportExerciseTypeResponse(List<ValidationError> errors)
        {
            Success = errors == null || !errors.Any();

            _errors = errors;
        }

        public void AddError(string error)
        {
            this._errors.Add(new ValidationError()
            {
                Status = (int)HttpStatusCode.UnprocessableEntity,
                Message = error
            });
        }
    }
}
