using System;
using Backend.Application.Business.Business.Import.ExerciseType;
using Backend.Application.Business.Business.Import.Training;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class ImportController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> ImportTraining([FromForm] ImportTrainingRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> ImportExerciseTypes([FromForm] Guid userId, [FromForm] IFormFile file)
        {
            return Ok(await Mediator.Send(new ImportExerciseTypeRequest() { Userid = userId, File = file }));
        }
    }
}