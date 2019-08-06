using Backend.Application.Business.Business.Authorization.ChangePassword;
using Backend.Application.Business.Business.Coaches.CreateCoach;
using Backend.Application.Business.Business.Coaches.DeleteCoach;
using Backend.Application.Business.Business.Coaches.GetAllCoaches;
using Backend.Application.Business.Business.Coaches.GetCoach;
using Backend.Application.Business.Business.Coaches.UpdateCoach;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class CoachsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllCoachsRequest()), sieveModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await GetSingle(async () => await Mediator.Send(new GetCoachRequest(id)));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateCoachRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateCoachRequest request)
        {
            return await Update(async () => await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await Delete(async () => await Mediator.Send(new DeleteCoachRequest(id)));
        }

       
    }
}
