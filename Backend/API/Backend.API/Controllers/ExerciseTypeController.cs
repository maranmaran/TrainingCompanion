using Backend.Business.Exercises.ExerciseTypeRequests.Create;
using Backend.Business.Exercises.ExerciseTypeRequests.Delete;
using Backend.Business.Exercises.ExerciseTypeRequests.Get;
using Backend.Business.Exercises.ExerciseTypeRequests.GetAll;
using Backend.Business.Exercises.ExerciseTypeRequests.Update;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class ExerciseTypeController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, CancellationToken cancellationToken = default)
        {
            //return Ok(await Cache.GetOrAddAsync(
            //    "ExerciseTypeController.GetAll",
            //    entry => Mediator.Send(new GetAllExerciseTypeRequest() { UserId = userId }, cancellationToken)
            //));

            return Ok(await Mediator.Send(new GetAllExerciseTypeRequest() { UserId = userId }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> GetPaged([FromBody] GetPagedExerciseTypeRequest request, CancellationToken cancellationToken = default)
        {
            //return Ok(await Cache.GetOrAddAsync(
            //    $"ExerciseTypeController.GetPaged-{request.UserId}/{request.PaginationModel.Page}/{request.PaginationModel.PageSize}",
            //    entry => Mediator.Send(request, cancellationToken)
            //));

            return Ok(await Mediator.Send(request, cancellationToken));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExerciseTypeRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateExerciseTypeRequest request, CancellationToken cancellationToken = default)
        {

            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeleteExerciseTypeRequest() { Id = id }, cancellationToken));
        }
    }
}