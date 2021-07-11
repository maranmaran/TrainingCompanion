using Backend.Business.TrainingLog.ExerciseRequests.Create;
using Backend.Business.TrainingLog.ExerciseRequests.CreateFull;
using Backend.Business.TrainingLog.ExerciseRequests.Delete;
using Backend.Business.TrainingLog.ExerciseRequests.Get;
using Backend.Business.TrainingLog.ExerciseRequests.GetAll;
using Backend.Business.TrainingLog.ExerciseRequests.UpdateFull;
using Backend.Business.TrainingLog.ExerciseRequests.UpdateMany;
using Backend.Domain.Entities.TrainingLog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class ExerciseController : BaseController
    {
        [HttpGet("{trainingId}")]
        public async Task<IActionResult> GetAll(Guid trainingId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetAllExerciseRequest() { TrainingId = trainingId }, cancellationToken));
        }

        [HttpGet("{exerciseId}")]
        public async Task<IActionResult> Get(Guid exerciseId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetExerciseRequest(exerciseId), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExerciseRequest request, CancellationToken cancellationToken = default)
        {
            RemoveCacheKeys($"Report/TrainingMetrics{request.TrainingId}");
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFull([FromBody] Exercise exercise, CancellationToken cancellationToken = default)
        {
            //RemoveCacheKeys($"Report/TrainingMetrics{exercise.TrainingId}");
            return Ok(await Mediator.Send(new CreateFullExerciseRequest(exercise), cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMany([FromBody] IEnumerable<Exercise> data, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new UpdateManyExercisesRequest(data), cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFull([FromBody] Exercise exercise, CancellationToken cancellationToken = default)
        {
            //RemoveCacheKeys($"Report/TrainingMetrics{exercise.TrainingId}");
            return Ok(await Mediator.Send(new UpdateFullExerciseRequest(exercise), cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            RemoveCacheKeys($"Report/TrainingMetrics");
            return Ok(await Mediator.Send(new DeleteExerciseRequest() { Id = id }, cancellationToken));
        }
    }
}