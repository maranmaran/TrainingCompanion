using Backend.Business.ExerciseType.Tag.Create;
using Backend.Business.ExerciseType.Tag.Delete;
using Backend.Business.ExerciseType.Tag.GetAll;
using Backend.Business.ExerciseType.Tag.Update;
using Backend.Business.ExerciseType.Tag.UpdateMany;
using Backend.Domain.Entities.ExerciseType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class TagController : BaseController
    {
        [HttpGet("{userId}/{typeId}")]
        public async Task<IActionResult> GetAll(Guid userId, Guid typeId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetAllTagRequest() { TagGroupId = typeId, UserId = userId }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTagRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMany([FromBody] IEnumerable<Tag> properties, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new UpdateManyTagRequest() { ExerciseProperties = properties }, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeleteTagRequest() { Id = id }, cancellationToken));
        }
    }
}