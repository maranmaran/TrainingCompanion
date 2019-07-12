using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    [ApiController]
    //[AllowAnonymous]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;
        private ISieveProcessor _sieveProcessor;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        protected ISieveProcessor SieveProcessor => _sieveProcessor ?? (_sieveProcessor = HttpContext.RequestServices.GetService<ISieveProcessor>());

        [NonAction]
        public async Task<IActionResult> GetQuery<T>(Func<Task<IQueryable<T>>> getEntitiesFunc, SieveModel sieveModel)
        {

            var entities = await getEntitiesFunc();

            var processedEntities = SieveProcessor.Apply(sieveModel, entities);

            return Ok(processedEntities);
        }

        [NonAction]
        public async Task<IActionResult> GetSingle<T>(Func<Task<T>> getEntityFunc)
        {

            var singleEntity = await getEntityFunc();

            if (singleEntity == null)
                return NotFound();

            return Ok(singleEntity);
        }

        [NonAction]
        public async Task<IActionResult> Create<T>(Func<Task<T>> createEntityFunc)
        {
            var createdEntity = await createEntityFunc();

            return Ok(createdEntity);
        }

        [NonAction]
        public async Task<IActionResult> Update<T>(Func<Task<T>> updateEntityFunc)
        {
            await updateEntityFunc();

            return Accepted();
        }

        [NonAction]
        public async Task<IActionResult> Delete<TKey>(Func<Task<TKey>> deleteEntityFunc)
        {
            await deleteEntityFunc();

            return Accepted();
        }
    }
}