using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.API.Middleware
{
    /// <summary>
    /// Gets JWT from cookie in request and sets auth header on the fly if it doesn't have it
    /// </summary>
    public class JwtToAuthHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtToAuthHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var name = "jwt";
            var token = context.Request.Cookies[name];

            if (token != null && !context.Request.Headers.ContainsKey("Authorization"))
                context.Request.Headers.Append("Authorization", $"Bearer {token}");

            await _next.Invoke(context);
        }
    }
}