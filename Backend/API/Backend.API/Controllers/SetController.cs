using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Backend.Business.TrainingLog.Set.Create;
using Backend.Business.TrainingLog.Set.Delete;
using Backend.Business.TrainingLog.Set.UpdateMany;

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