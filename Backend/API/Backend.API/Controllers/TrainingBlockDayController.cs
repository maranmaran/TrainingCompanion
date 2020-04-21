using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Business.TrainingPrograms.DayRequests.Create;
using Backend.Business.TrainingPrograms.DayRequests.Delete;
using Backend.Business.TrainingPrograms.DayRequests.Get;
using Backend.Business.TrainingPrograms.DayRequests.GetAll;
using Backend.Business.TrainingPrograms.DayRequests.Update;

namespace Backend.API.Controllers
{
    public class TrainingBlockDayController : BaseController
    {
        [HttpGet("{trainingBlockId}")]
        public async Task<IActionResult> GetAll(Guid trainingBlockId, CancellationToken cancellationToken = default)
        {

            return Ok(await Mediator.Send(new GetAllTrainingBlockDaysRequest(trainingBlockId), cancellationToken));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken = default)
        {

            return Ok(await Mediator.Send(new GetTrainingBlockDayRequest(id), cancellationToken));
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