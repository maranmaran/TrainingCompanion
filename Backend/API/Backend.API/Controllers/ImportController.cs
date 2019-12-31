using Backend.Application.Business.Business.Import.ExerciseType;
using Backend.Application.Business.Business.Import.Training;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class ImportController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> ImportTraining([FromBody] ImportTrainingRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> ImportExerciseTypes([FromBody] ImportExerciseTypeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}