using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;
using Backend.Business.TrainingLog.Training.Create;
using Backend.Business.TrainingLog.Training.Delete;
using Backend.Business.TrainingLog.Training.Get;
using Backend.Business.TrainingLog.Training.GetAll;
using Backend.Business.TrainingLog.Training.GetByMonth;
using Backend.Business.TrainingLog.Training.GetByWeek;
using Backend.Business.TrainingLog.Training.Update;

namespace Backend.API.Controllers
{
    public class TrainingController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, [FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllTrainingRequest() { ApplicationUserId = userId }), sieveModel);
        }

        [HttpGet("{trainingId}")]
        public async Task<IActionResult> Get(Guid trainingId, [FromQuery]SieveModel sieveModel)
        {
            return Ok(await Mediator.Send(new GetTrainingRequest(trainingId)));
        }

        [HttpGet("{userId}/{month}/{year}")]
        public async Task<IActionResult> GetAllByMonth(Guid userId, int month, int year)
        {
            return Ok(await Mediator.Send(new GetAllTrainingsByMonthRequest(userId, month, year)));
        }

        [HttpGet("{userId}/{weekStart}/{weekEnd}")]
        public async Task<IActionResult> GetAllByWeek(Guid userId, DateTime weekStart, DateTime weekEnd, [FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllTrainingsByWeekRequest(userId, weekStart, weekEnd)), sieveModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTrainingRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTrainingRequest request)
        {
            return await Update(async () => await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteTrainingRequest() { Id = id }));
        }
    }
}