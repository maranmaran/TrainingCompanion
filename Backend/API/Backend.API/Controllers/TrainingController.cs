using Backend.Business.TrainingLog.TrainingRequests.Create;
using Backend.Business.TrainingLog.TrainingRequests.Delete;
using Backend.Business.TrainingLog.TrainingRequests.Get;
using Backend.Business.TrainingLog.TrainingRequests.GetAll;
using Backend.Business.TrainingLog.TrainingRequests.GetByMonth;
using Backend.Business.TrainingLog.TrainingRequests.GetByWeek;
using Backend.Business.TrainingLog.TrainingRequests.Update;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class TrainingController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetAllTrainingRequest() { ApplicationUserId = userId }, cancellationToken));
        }

        [HttpGet("{trainingId}")]
        public async Task<IActionResult> Get(Guid trainingId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetTrainingRequest(trainingId), cancellationToken));
        }

        [HttpGet("{userId}/{month}/{year}")]
        public async Task<IActionResult> GetAllByMonth(Guid userId, int month, int year, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetAllTrainingsByMonthRequest(userId, month, year), cancellationToken));
        }

        [HttpGet("{userId}/{weekStart}/{weekEnd}")]
        public async Task<IActionResult> GetAllByWeek(Guid userId, DateTime weekStart, DateTime weekEnd, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetAllTrainingsByWeekRequest(userId, weekStart, weekEnd), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainingRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTrainingRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeleteTrainingRequest() { Id = id }, cancellationToken));
        }
    }
}