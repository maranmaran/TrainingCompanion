using Backend.Business.ProgressTracking.BodyweightRequests.Create;
using Backend.Business.ProgressTracking.BodyweightRequests.Delete;
using Backend.Business.ProgressTracking.BodyweightRequests.GetAll;
using Backend.Business.ProgressTracking.BodyweightRequests.Update;
using Backend.Domain.Entities.ProgressTracking;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class BodyweightController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId, CancellationToken cancellationToken = default)
        {
            return Ok(await Cache.GetOrAddAsync(
                "Bodyweight/GetAll",
                entry => Mediator.Send(new GetAllBodyweightRequest(userId), cancellationToken))
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Bodyweight entity, CancellationToken cancellationToken = default)
        {
            Cache.Remove("Report/BodyweightMetrics");
            Cache.Remove("Bodyweight/GetAll");
            return Ok(await Mediator.Send(new CreateBodyweightRequest(entity), cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Bodyweight entity, CancellationToken cancellationToken = default)
        {
            Cache.Remove("Report/BodyweightMetrics");
            Cache.Remove("Bodyweight/GetAll");
            return Ok(await Mediator.Send(new UpdateBodyweightRequest(entity), cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            Cache.Remove("Report/BodyweightMetrics");
            Cache.Remove("Bodyweight/GetAll");
            return Ok(await Mediator.Send(new DeleteBodyweightRequest(id), cancellationToken));
        }
    }
}
