﻿using Backend.Business.ProgressTracking.PersonalBestRequests.Create;
using Backend.Business.ProgressTracking.PersonalBestRequests.Delete;
using Backend.Business.ProgressTracking.PersonalBestRequests.Get;
using Backend.Business.ProgressTracking.PersonalBestRequests.GetAll;
using Backend.Business.ProgressTracking.PersonalBestRequests.Update;
using Backend.Domain.Entities.ProgressTracking;
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

        [HttpGet("{exerciseTypeId}")]
        public async Task<IActionResult> Get(Guid exerciseTypeId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetPersonalBestRequest() { ExerciseTypeId = exerciseTypeId }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonalBest entity, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new CreatePersonalBestRequest(entity), cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonalBest entity, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new UpdatePersonalBestRequest(entity), cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeletePersonalBestRequest(id), cancellationToken));
        }
    }
}
