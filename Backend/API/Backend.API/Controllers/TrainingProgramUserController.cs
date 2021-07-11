using Backend.Business.TrainingPrograms.ProgramUserRequests.Create;
using Backend.Business.TrainingPrograms.ProgramUserRequests.Delete;
using Backend.Business.TrainingPrograms.ProgramUserRequests.GetAll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class TrainingProgramUserController : BaseController
    {
        [HttpGet("{programId}")]
        public async Task<IActionResult> GetAll(Guid programId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetAllTrainingProgramUsersRequest(programId), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainingProgramUserRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeleteTrainingProgramUserRequest(id), cancellationToken));
        }
    }
}