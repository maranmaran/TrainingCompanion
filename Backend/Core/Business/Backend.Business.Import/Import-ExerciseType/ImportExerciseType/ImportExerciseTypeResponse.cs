using Backend.Common;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Backend.Business.Import.ImportExerciseType
{
    public class ImportExerciseTypeResponse
    {
        public bool Success { get; set; }
        public List<ValidationError> Errors { get; set; } = new List<ValidationError>();

        public ImportExerciseTypeResponse(bool success)
        {
            Success = success;
        }

        public ImportExerciseTypeResponse(List<ValidationError> errors)
        {
            Success = errors == null || !errors.Any();

            Errors = errors;
        }

        public void AddError(string error)
        {
            this.Success = false;
            this.Errors.Add(new ValidationError()
            {
                Status = (int)HttpStatusCode.UnprocessableEntity,
                Message = error
            });
        }
    }
}