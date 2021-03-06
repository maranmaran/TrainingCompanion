﻿using Backend.Business.TrainingPrograms.ProgramRequests.Create;
using Backend.Business.TrainingPrograms.ProgramRequests.Delete;
using Backend.Business.TrainingPrograms.ProgramRequests.Get;
using Backend.Business.TrainingPrograms.ProgramRequests.GetAll;
using Backend.Business.TrainingPrograms.ProgramRequests.Update;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class TrainingProgramController : BaseController
    {
        [HttpGet("{creatorId}")]
        public async Task<IActionResult> GetAll(Guid creatorId, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetAllTrainingProgramsRequest(creatorId), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new GetTrainingProgramRequest(id), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainingProgramRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTrainingProgramRequest request, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await Mediator.Send(new DeleteTrainingProgramRequest(id), cancellationToken));
        }
    }
}