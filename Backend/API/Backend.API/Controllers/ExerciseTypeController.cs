using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;
using Backend.Business_ExerciseType.ExerciseType.Create;
using Backend.Business_ExerciseType.ExerciseType.Delete;
using Backend.Business_ExerciseType.ExerciseType.Get;
using Backend.Business_ExerciseType.ExerciseType.GetAll;
using Backend.Business_ExerciseType.ExerciseType.Update;

namespace Backend.API.Controllers
{
    public class ExerciseTypeController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, [FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllExerciseTypeRequest() { UserId = userId }), sieveModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetPaged(GetPagedExerciseTypeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseTypeRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateExerciseTypeRequest request)
        {
            return await Update(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteExerciseTypeRequest() { Id = id }));
        }
    }
}