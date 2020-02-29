using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Backend.Business.Import.Import.GetImportSample;
using Backend.Business.Import.Import.ImportExerciseType;
using Backend.Business.Import.Import.ImportTraining;
using Backend.Business.Import.Models;

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
            return BadRequest();
            return Ok(await Mediator.Send(new ImportExerciseTypeRequest() { Userid = userId, File = file }));
        }

        [HttpGet("{importType}/{sampleType}")]
        public async Task<IActionResult> GetSample(ImportType importType, SampleType sampleType)
        {
            return await Mediator.Send(new GetImportSampleRequest { ImportType = importType, SampleType = sampleType });
        }
    }
}