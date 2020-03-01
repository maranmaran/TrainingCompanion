using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Business.ProgressTracking.PersonalBestRequests.Create;
using Backend.Business.ProgressTracking.PersonalBestRequests.Delete;
using Backend.Business.ProgressTracking.PersonalBestRequests.GetAll;
using Backend.Business.ProgressTracking.PersonalBestRequests.Update;
using Backend.Domain.Entities.ProgressTracking;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    public class PersonalBestController: BaseController
    {
        [HttpGet("{exerciseTypeId}")]
        public async Task<IActionResult> GetAll(Guid exerciseTypeId)
        {
            return Ok(await Mediator.Send(new GetAllPersonalBestRequest(exerciseTypeId)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonalBest entity)
        {
            return Ok(await Mediator.Send(new CreatePersonalBestRequest(entity)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(PersonalBest entity)
        {
            return Ok(await Mediator.Send(new UpdatePersonalBestRequest(entity)));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeletePersonalBestRequest(id)));
        }
    }
}
