using Backend.Business.TrainingLog.ExerciseRequests.Create;
using Backend.Business.TrainingLog.ExerciseRequests.Delete;
using Backend.Business.TrainingLog.ExerciseRequests.Get;
using Backend.Business.TrainingLog.ExerciseRequests.GetAll;
using Backend.Business.TrainingLog.ExerciseRequests.UpdateMany;
using Backend.Domain.Entities.TrainingLog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class ExerciseController : BaseController
    {
        [HttpGet("{trainingId}")]
        public async Task<IActionResult> GetAll(Guid trainingId)
        {
            return Ok(await Mediator.Send(new GetAllExerciseRequest() { TrainingId = trainingId }));
        }

        [HttpGet("{exerciseId}")]
        public async Task<IActionResult> Get(Guid exerciseId)
        {
            return Ok(await Mediator.Send(new GetExerciseRequest(exerciseId)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExerciseRequest request)
        {
            return Ok(await Mediator.Send(request));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMany([FromBody] IEnumerable<Exercise> data)
        {
            return Ok(await Mediator.Send(new UpdateManyExercisesRequest(data)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteExerciseRequest() { Id = id }));
        }
    }
}