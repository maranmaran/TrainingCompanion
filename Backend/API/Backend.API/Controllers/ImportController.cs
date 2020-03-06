using Backend.Business.Import.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Backend.Business.Import.Models.Shared;
using Backend.Business.Import.Requests.ExerciseTypeRequests.ImportExerciseType;
using Backend.Business.Import.Requests.ImportRequests.GetImportSample;
using Backend.Business.Import.Requests.TrainingRequests.ImportTraining;

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

        [HttpGet("{importType}/{sampleType}")]
        public async Task<IActionResult> GetSample(ImportType importType, SampleType sampleType)
        {
            return Ok(await Mediator.Send(new GetImportSampleRequest { ImportType = importType, SampleType = sampleType }));
        }
    }
}