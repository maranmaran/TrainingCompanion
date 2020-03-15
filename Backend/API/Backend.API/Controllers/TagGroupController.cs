using Backend.Business.ExerciseType.TagGroup.Create;
using Backend.Business.ExerciseType.TagGroup.Delete;
using Backend.Business.ExerciseType.TagGroup.GetAll;
using Backend.Business.ExerciseType.TagGroup.Update;
using Backend.Business.ExerciseType.TagGroup.UpdateMany;
using Backend.Domain.Entities.ExerciseType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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