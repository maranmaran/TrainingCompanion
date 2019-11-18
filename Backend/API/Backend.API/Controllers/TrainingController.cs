using Backend.Application.Business.Business.Training.Create;
using Backend.Application.Business.Business.Training.Delete;
using Backend.Application.Business.Business.Training.GetAll;
using Backend.Application.Business.Business.Training.GetByMonth;
using Backend.Application.Business.Business.Training.GetByWeek;
using Backend.Application.Business.Business.Training.Update;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Training.Get;
using Backend.Application.Business.Business.Media.UploadMedia;

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
            return Ok( await Mediator.Send(new GetTrainingRequest(trainingId)) );
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
