using Backend.Business.Export.ExportTrainingData;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

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