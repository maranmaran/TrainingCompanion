using Backend.Application.Business.Business.Tag.Create;
using Backend.Application.Business.Business.Tag.Delete;
using Backend.Application.Business.Business.Tag.GetAll;
using Backend.Application.Business.Business.Tag.Update;
using Backend.Application.Business.Business.Tag.UpdateMany;
using Backend.Domain.Entities.ExerciseType;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class TagController : BaseController
    {
        [HttpGet("{userId}/{typeId}")]
        public async Task<IActionResult> GetAll(Guid userId, Guid typeId, [FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllTagRequest() { TagGroupId = typeId, UserId = userId }), sieveModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTagRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTagRequest request)
        {
            return await Update(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMany(IEnumerable<Tag> properties)
        {
            return Ok(await Mediator.Send(new UpdateManyTagRequest() { ExerciseProperties = properties }));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteTagRequest() { Id = id }));
        }
    }
}