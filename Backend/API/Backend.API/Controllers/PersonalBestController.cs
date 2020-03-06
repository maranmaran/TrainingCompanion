using Backend.Business.ProgressTracking.PersonalBestRequests.Create;
using Backend.Business.ProgressTracking.PersonalBestRequests.Delete;
using Backend.Business.ProgressTracking.PersonalBestRequests.GetAll;
using Backend.Business.ProgressTracking.PersonalBestRequests.Update;
using Backend.Domain.Entities.ProgressTracking;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class PersonalBestController : BaseController
    {
        //[HttpGet("{exerciseTypeId}")]
        //public async Task<IActionResult> GetAll(Guid exerciseTypeId)
        //{
        //    return Ok(await Mediator.Send(new GetAllPersonalBestRequest(exerciseTypeId)));
        //}

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            return Ok(await Mediator.Send(new GetAllPersonalBestRequest(userId)));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonalBest entity)
        {
            return Ok(await Mediator.Send(new CreatePersonalBestRequest(entity)));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonalBest entity)
        {
            return Ok(await Mediator.Send(new UpdatePersonalBestRequest(entity)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeletePersonalBestRequest(id)));
        }
    }
}
