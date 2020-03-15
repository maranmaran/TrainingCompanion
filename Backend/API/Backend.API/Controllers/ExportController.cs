using System.Threading;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend.Business.Export.ExportTrainingData;

namespace Backend.API.Controllers
{
    public class ExportController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> ExportTraining([FromBody] ExportTrainingDataRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }
    }
}