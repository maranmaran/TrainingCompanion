using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Business.Exercises.TagGroupRequests.Create;
using Backend.Business.Exercises.TagGroupRequests.Delete;
using Backend.Business.Exercises.TagGroupRequests.GetAll;
using Backend.Business.Exercises.TagGroupRequests.Update;
using Backend.Business.Exercises.TagGroupRequests.UpdateMany;
using Backend.Domain.Entities.Exercises;

namespace Backend.API.Controllers
{
    public class TagGroupController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetAllTagGroupRequest() { ApplicationUserId = userId }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TagGroup tagGroup, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new CreateTagGroupRequest(tagGroup), cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TagGroup tagGroup, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new UpdateTagGroupRequest(tagGroup), cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMany([FromBody] IEnumerable<TagGroup> request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new UpdateManyTagGroupRequest() { TagGroups = request }, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeleteTagGroupRequest() { Id = id }, cancellationToken));
        }
    }
}