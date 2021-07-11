using Backend.Business.Import.GetImportSample;
using Backend.Business.Import.ImportExerciseType;
using Backend.Business.Import.ImportTraining;
using Backend.Business.Import.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class ImportController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> ImportTraining([FromForm] ImportTrainingRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> ImportExerciseTypes([FromForm] Guid userId, [FromForm] IFormFile file, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new ImportExerciseTypeRequest() { Userid = userId, File = file }, cancellationToken));
        }

        [HttpGet("{importType}/{sampleType}")]
        public async Task<IActionResult> GetSample(ImportType importType, SampleType sampleType, CancellationToken cancellationToken = default)
        {
            return await Mediator.Send(new GetImportSampleRequest { ImportType = importType, SampleType = sampleType }, cancellationToken);
        }
    }
}