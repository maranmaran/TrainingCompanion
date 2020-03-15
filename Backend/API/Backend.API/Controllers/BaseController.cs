using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.API.Controllers
{
    [ApiController]
    //[AllowAnonymous]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private IAppCache _cache;
        protected IAppCache Cache => _cache ??= HttpContext.RequestServices.GetService<IAppCache>();
    }
}