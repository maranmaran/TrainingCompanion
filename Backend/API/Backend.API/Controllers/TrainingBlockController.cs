using Backend.Business.TrainingPrograms.TrainingBlockRequests.Create;
using Backend.Business.TrainingPrograms.TrainingBlockRequests.Delete;
using Backend.Business.TrainingPrograms.TrainingBlockRequests.Get;
using Backend.Business.TrainingPrograms.TrainingBlockRequests.GetAll;
using Backend.Business.TrainingPrograms.TrainingBlockRequests.Update;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class TrainingBlockController : BaseController
    {
        [HttpGet("{trainingProgramId}")]
        public async Task<IActionResult> GetAll(Guid trainingProgramId, CancellationToken cancellationToken = default)
        {

            return Ok(await Mediator.Send(new GetAllTrainingBlocksRequest(trainingProgramId), cancellationToken));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken = default)
        {

            return Ok(await Mediator.Send(new GetTrainingBlockRequest(id), cancellationToken));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainingBlockRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTrainingBlockRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeleteTrainingBlockRequest(id), cancellationToken));
        }
    }
}