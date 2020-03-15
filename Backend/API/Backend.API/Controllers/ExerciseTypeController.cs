using Backend.Business.ExerciseType.ExerciseType.Create;
using Backend.Business.ExerciseType.ExerciseType.Delete;
using Backend.Business.ExerciseType.ExerciseType.Get;
using Backend.Business.ExerciseType.ExerciseType.GetAll;
using Backend.Business.ExerciseType.ExerciseType.Update;
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
            return Ok(await Mediator.Send(new GetAllExerciseTypeRequest() { UserId = userId }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> GetPaged([FromBody] GetPagedExerciseTypeRequest request, CancellationToken cancellationToken = default)
        {
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