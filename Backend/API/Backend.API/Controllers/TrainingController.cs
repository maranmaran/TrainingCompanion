using Backend.Application.Business.Business.Training.Create;
using Backend.Application.Business.Business.Training.Delete;
using Backend.Application.Business.Business.Training.GetAll;
using Backend.Application.Business.Business.Training.Update;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class TrainingController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, [FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllTrainingRequest() { UserId = userId }), sieveModel);
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

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteTrainingRequest() { Id = id }));
        }

    }
}
