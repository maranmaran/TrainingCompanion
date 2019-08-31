using Backend.Application.Business.Business.ExercisePropertyType.Create;
using Backend.Application.Business.Business.ExercisePropertyType.Delete;
using Backend.Application.Business.Business.ExercisePropertyType.GetAll;
using Backend.Application.Business.Business.ExercisePropertyType.Update;
using Backend.Application.Business.Business.ExercisePropertyType.UpdateMany;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;
using Backend.Domain.Entities.ExerciseType;

namespace Backend.API.Controllers
{
    public class ExercisePropertyTypeController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, [FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllExercisePropertyTypeRequest() { ApplicationUserId = userId }), sieveModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExercisePropertyTypeRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ExercisePropertyType exercisePropertyType)
        {
            return await Update(async () => await Mediator.Send(new UpdateExercisePropertyTypeRequest(exercisePropertyType)));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMany(UpdateManyExercisePropertyTypeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteExercisePropertyTypeRequest() { Id = id }));
        }

    }
}
