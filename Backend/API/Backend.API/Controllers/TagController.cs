using Backend.Business.ExerciseType.Tag.Create;
using Backend.Business.ExerciseType.Tag.Delete;
using Backend.Business.ExerciseType.Tag.GetAll;
using Backend.Business.ExerciseType.Tag.Update;
using Backend.Business.ExerciseType.Tag.UpdateMany;
using Backend.Domain.Entities.ExerciseType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class TagController : BaseController
    {
        [HttpGet("{userId}/{typeId}")]
        public async Task<IActionResult> GetAll(Guid userId, Guid typeId)
        {
            return Ok(await Mediator.Send(new GetAllTagRequest() { TagGroupId = typeId, UserId = userId }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTagRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMany([FromBody] IEnumerable<Tag> properties)
        {
            return Ok(await Mediator.Send(new UpdateManyTagRequest() { ExerciseProperties = properties }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteTagRequest() { Id = id }));
        }
    }
}