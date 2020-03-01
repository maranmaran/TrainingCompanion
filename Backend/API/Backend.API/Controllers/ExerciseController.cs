using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Business.TrainingLog.ExerciseRequests.Create;
using Backend.Business.TrainingLog.ExerciseRequests.Delete;
using Backend.Business.TrainingLog.ExerciseRequests.Get;
using Backend.Business.TrainingLog.ExerciseRequests.GetAll;
using Backend.Business.TrainingLog.ExerciseRequests.UpdateMany;
using Backend.Domain.Entities.TrainingLog;

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
        public async Task<IActionResult> UpdateMany(IEnumerable<Exercise> data)
        {
            return await Update(async () => await Mediator.Send(new UpdateManyExercisesRequest(data)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteExerciseRequest() { Id = id }));
        }
    }
}