using System.Threading;
using System.Threading.Tasks;
using Backend.Business.TrainingPrograms.ProgramUserRequests.Create;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    public class TrainingProgramUserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainingProgramUserRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

    }
}