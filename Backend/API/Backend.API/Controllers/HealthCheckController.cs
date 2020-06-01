using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [AllowAnonymous]
    public class HealthCheckController : BaseController
    {
        [HttpGet]
        public ActionResult Ping()
        {
            return Ok(true);
        }
    }
}
