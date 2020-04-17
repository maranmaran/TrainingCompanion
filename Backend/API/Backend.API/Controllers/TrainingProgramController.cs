

using Backend.Business.TrainingPrograms.TrainingProgramRequests.Create;
using Backend.Business.TrainingPrograms.TrainingProgramRequests.Delete;
using Backend.Business.TrainingPrograms.TrainingProgramRequests.GetAll;
using Backend.Business.TrainingPrograms.TrainingProgramRequests.Update;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class TrainingProgramController : BaseController
    {
        [HttpGet("{creatorId}")]
        public async Task<IActionResult> GetAll(Guid creatorId, CancellationToken cancellationToken = default)
        {

            return Ok(await Mediator.Send(new GetAllTrainingProgramsRequest(creatorId), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainingProgramRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTrainingProgramRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeleteTrainingProgramRequest(id), cancellationToken));
        }
    }
}
