using Backend.Business.TrainingLog.SetRequests.Create;
using Backend.Business.TrainingLog.SetRequests.Delete;
using Backend.Business.TrainingLog.SetRequests.UpdateMany;
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
            return Ok(await Mediator.Send(request));
        }


        [HttpPost]
        public async Task<IActionResult> UpdateMany(UpdateManySetsRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteSetRequest() { Id = id }));
        }
    }
}