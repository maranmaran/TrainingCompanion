using Backend.Business.TrainingLog.TrainingRequests.Create;
using Backend.Business.TrainingLog.TrainingRequests.Delete;
using Backend.Business.TrainingLog.TrainingRequests.Get;
using Backend.Business.TrainingLog.TrainingRequests.GetAll;
using Backend.Business.TrainingLog.TrainingRequests.GetByMonth;
using Backend.Business.TrainingLog.TrainingRequests.GetByWeek;
using Backend.Business.TrainingLog.TrainingRequests.Update;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class TrainingController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            return Ok(await Mediator.Send(new GetAllTrainingRequest() { ApplicationUserId = userId }));
        }

        [HttpGet("{trainingId}")]
        public async Task<IActionResult> Get(Guid trainingId)
        {
            return Ok(await Mediator.Send(new GetTrainingRequest(trainingId)));
        }

        [HttpGet("{userId}/{month}/{year}")]
        public async Task<IActionResult> GetAllByMonth(Guid userId, int month, int year)
        {
            return Ok(await Mediator.Send(new GetAllTrainingsByMonthRequest(userId, month, year)));
        }

        [HttpGet("{userId}/{weekStart}/{weekEnd}")]
        public async Task<IActionResult> GetAllByWeek(Guid userId, DateTime weekStart, DateTime weekEnd)
        {
            return Ok(await Mediator.Send(new GetAllTrainingsByWeekRequest(userId, weekStart, weekEnd)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainingRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTrainingRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteTrainingRequest() { Id = id }));
        }
    }
}