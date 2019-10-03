using Backend.Application.Business.Business.Exercise.Create;
using Backend.Application.Business.Business.Exercise.Delete;
using Backend.Application.Business.Business.Exercise.GetAll;
using Backend.Application.Business.Business.Exercise.Update;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Exercise.Get;

namespace Backend.API.Controllers
{
    public class ExerciseController : BaseController
    {
        [HttpGet("{trainingId}")]
        public async Task<IActionResult> GetAll(Guid trainingId, [FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllExerciseRequest() { TrainingId = trainingId }), sieveModel);
        }


        [HttpGet("{exerciseId}")]
        public async Task<IActionResult> Get(Guid exerciseId)
        {
            return Ok(await Mediator.Send(new GetExerciseRequest(exerciseId)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateExerciseRequest request)
        {
            return await Update(async () => await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteExerciseRequest() { Id = id }));
        }

    }
}
