using Backend.Application.Business.Business.Athletes.CreateAthlete;
using Backend.Application.Business.Business.Athletes.DeleteAthlete;
using Backend.Application.Business.Business.Athletes.GetAllAthletes;
using Backend.Application.Business.Business.Athletes.UpdateAthlete;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class AthleteController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllAthletesRequest()), sieveModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByCoachId(Guid id, [FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllAthletesRequest(id)), sieveModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAthleteRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateAthleteRequest request)
        {
            return await Update(async () => await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await Delete(async () => await Mediator.Send(new DeleteAthleteRequest(id)));
        }
    }
}
