using Backend.Application.Business.Business.TagGroup.Create;
using Backend.Application.Business.Business.TagGroup.Delete;
using Backend.Application.Business.Business.TagGroup.GetAll;
using Backend.Application.Business.Business.TagGroup.Update;
using Backend.Application.Business.Business.TagGroup.UpdateMany;
using Backend.Domain.Entities.ExerciseType;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class TagGroupController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, [FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllTagGroupRequest() { ApplicationUserId = userId }), sieveModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagGroup tagGroup)
        {
            return await Create(async () => await Mediator.Send(new CreateTagGroupRequest(tagGroup)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(TagGroup tagGroup)
        {
            return await Update(async () => await Mediator.Send(new UpdateTagGroupRequest(tagGroup)));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMany(IEnumerable<TagGroup> request)
        {
            return Ok(await Mediator.Send(new UpdateManyTagGroupRequest() { TagGroups = request }));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteTagGroupRequest() { Id = id }));
        }
    }
}