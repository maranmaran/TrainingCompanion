using Backend.Application.Business.Business.Export.Training;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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