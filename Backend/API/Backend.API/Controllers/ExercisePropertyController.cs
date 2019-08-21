using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Application.Business.Business.ExerciseProperty.Create;
using Backend.Application.Business.Business.ExerciseProperty.Delete;
using Backend.Application.Business.Business.ExerciseProperty.GetAll;
using Backend.Application.Business.Business.ExerciseProperty.Update;
using Backend.Application.Business.Business.ExerciseProperty.UpdateMany;
using Backend.Application.Business.Business.ExercisePropertyType.UpdateMany;
using Backend.Domain.Entities.ExerciseType;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Backend.API.Controllers
{
    public class ExercisePropertyController : BaseController
    {
        [HttpGet("{userId}/{typeId}")]
        public async Task<IActionResult> GetAll(Guid userId, Guid typeId, [FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllExercisePropertyRequest() { ExercisePropertyTypeId = typeId, UserId = userId}), sieveModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExercisePropertyRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateExercisePropertyRequest request)
        {
            return await Update(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMany(IEnumerable<ExerciseProperty> properties)
        {
            return Ok(await Mediator.Send(new UpdateManyExercisePropertyRequest() {ExerciseProperties = properties}));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteExercisePropertyRequest() { Id = id }));
        }

    }
}