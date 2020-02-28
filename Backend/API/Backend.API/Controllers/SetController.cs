using Backend.Application.Business.Business.Set.Create;
using Backend.Application.Business.Business.Set.Delete;
using Backend.Application.Business.Business.Set.UpdateMany;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class SetController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateSetRequest request)
        {
            return await Create(async () => await Mediator.Send(request));
        }


        [HttpPost]
        public async Task<IActionResult> UpdateMany(UpdateManySetsRequest request)
        {
            return await Update(async () => await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteSetRequest() { Id = id }));
        }
    }
}