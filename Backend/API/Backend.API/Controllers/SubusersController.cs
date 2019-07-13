using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Subusers.CreateSubuser;
using Backend.Application.Business.Business.Subusers.DeleteSubuser;
using Backend.Application.Business.Business.Subusers.GetAllSubusers;

namespace Backend.API.Controllers
{
    public class SubusersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllSubusersRequest()), sieveModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubuserRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await Delete(async () => await Mediator.Send(new DeleteSubuserRequest(id)));
        }
    }
}
