using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;
using System.Linq;

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

        /// <summary>
        ///  Cache keys and these helper methods are here till
        /// PRs for predicate keys removal and clear all from cache are passed
        /// https://github.com/alastairtree/LazyCache/pull/87
        /// https://github.com/alastairtree/LazyCache/pull/91
        ///
        /// Or perhaps alternative to LazyCache?
        /// So far so good so no need to change
        /// </summary>

        private IAppCache _cache;
        protected IAppCache Cache => _cache ??= HttpContext.RequestServices.GetService<IAppCache>();

        private static readonly ConcurrentBag<string> CacheKeys = new ConcurrentBag<string>();

        protected void AddCacheKey(string key) => CacheKeys.Add(key);

        protected void RemoveCacheKeys(params string[] keys)
        {
            foreach (var key in CacheKeys)
            {
                if (keys.Any(x => key.Contains(x)))
                {
                    Cache.Remove(key);
                }
            }
        }
    }
}