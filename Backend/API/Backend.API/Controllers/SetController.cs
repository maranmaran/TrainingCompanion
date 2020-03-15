using Backend.Business.TrainingLog.SetRequests.Create;
using Backend.Business.TrainingLog.SetRequests.Delete;
using Backend.Business.TrainingLog.SetRequests.UpdateMany;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class SetController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSetRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMany([FromBody] UpdateManySetsRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeleteSetRequest() { Id = id }, cancellationToken));
        }
    }
}