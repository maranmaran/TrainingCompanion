using Backend.Business.TrainingPrograms.TrainingBlockDayRequests.Delete;
using Backend.Business.TrainingPrograms.TrainingBlockDayRequests.GetAll;
using Backend.Business.TrainingPrograms.TrainingBlockDayRequests.Update;
using Backend.Business.TrainingPrograms.TrainingBlockRequests.Create;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Business.TrainingPrograms.TrainingBlockDayRequests.Create;

namespace Backend.API.Controllers
{
    public class TrainingBlockDayController : BaseController
    {
        [HttpGet("{trainingBlockId}")]
        public async Task<IActionResult> GetAll(Guid trainingBlockId, CancellationToken cancellationToken = default)
        {

            return Ok(await Mediator.Send(new GetAllTrainingBlockDaysRequest(trainingBlockId), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainingBlockDayRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTrainingBlockDayRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeleteTrainingBlockDayRequest(id), cancellationToken));
        }
    }
}