using Backend.Business.ExerciseType.ExerciseType.Create;
using Backend.Business.ExerciseType.ExerciseType.Delete;
using Backend.Business.ExerciseType.ExerciseType.Get;
using Backend.Business.ExerciseType.ExerciseType.GetAll;
using Backend.Business.ExerciseType.ExerciseType.Update;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class ExerciseTypeController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            return Ok(await Mediator.Send(new GetAllExerciseTypeRequest() { UserId = userId }));
        }

        [HttpPost]
        public async Task<IActionResult> GetPaged([FromBody] GetPagedExerciseTypeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExerciseTypeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateExerciseTypeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteExerciseTypeRequest() { Id = id }));
        }
    }
}