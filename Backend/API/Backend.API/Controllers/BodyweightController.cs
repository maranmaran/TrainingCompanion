using Backend.Business.ProgressTracking.BodyweightRequests.Create;
using Backend.Business.ProgressTracking.BodyweightRequests.Delete;
using Backend.Business.ProgressTracking.BodyweightRequests.GetAll;
using Backend.Business.ProgressTracking.BodyweightRequests.Update;
using Backend.Domain.Entities.ProgressTracking;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class BodyweightController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            return Ok(await Mediator.Send(new GetAllBodyweightRequest(userId)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Bodyweight entity)
        {
            return Ok(await Mediator.Send(new CreateBodyweightRequest(entity)));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Bodyweight entity)
        {
            return Ok(await Mediator.Send(new UpdateBodyweightRequest(entity)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteBodyweightRequest(id)));
        }
    }
}
