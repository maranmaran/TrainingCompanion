using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Import.ExerciseType;
using Backend.Application.Business.Business.Import.Training;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    public class ImportController: BaseController
    {
        [HttpPost]
        public async Task<IActionResult> ImportTraining(IFormFile importFile, Guid userId)
        {
            return Ok(await Mediator.Send(new ImportTrainingRequest() {File = importFile, Userid = userId}));
        }

        [HttpPost]
        public async Task<IActionResult> ImportExerciseTypes(IFormFile importFile, Guid userId)
        {
            return Ok(await Mediator.Send(new ImportExerciseTypeRequest() { File = importFile, Userid = userId }));
        }
    }
}