using Backend.Business.ProgressTracking.PersonalBestRequests.Create;
using Backend.Business.ProgressTracking.PersonalBestRequests.Delete;
using Backend.Business.ProgressTracking.PersonalBestRequests.Get;
using Backend.Business.ProgressTracking.PersonalBestRequests.GetAll;
using Backend.Business.ProgressTracking.PersonalBestRequests.Update;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class PersonalBestController : BaseController
    {
        [HttpGet("{exerciseTypeId}")]
        public async Task<IActionResult> GetAll(Guid exerciseTypeId, int? lowerRepRage, int? upperRepRange, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetAllPersonalBestRequest(exerciseTypeId, lowerRepRage, upperRepRange), cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid exerciseTypeId, [FromQuery] Guid exerciseId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetPersonalBestRequest() { ExerciseTypeId = exerciseTypeId, ExerciseId = exerciseId }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonalBestRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePersonalBestRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeletePersonalBestRequest(id), cancellationToken));
        }
    }
}