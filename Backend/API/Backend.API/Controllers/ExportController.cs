using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend.Business.Export.Export.Training;

namespace Backend.API.Controllers
{
    public class ExportController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> ExportTraining(ExportTrainingDataRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}