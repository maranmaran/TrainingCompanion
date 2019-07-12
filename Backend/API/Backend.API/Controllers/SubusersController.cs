using Backend.Application.Business.Business.Subusers.Commands.Delete;
using Backend.Application.Business.Business.Subusers.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Subusers.Commands.Create;

namespace Backend.API.Controllers
{
    public class SubusersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]SieveModel sieveModel)
        {
            return await GetQuery(async () => await Mediator.Send(new GetAllSubusersQuery()), sieveModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubuserCommand command)
        {
            return await Create(async () => await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await Delete(async () => await Mediator.Send(new DeleteSubuserCommand(id)));
        }
    }
}
