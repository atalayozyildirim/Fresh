
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fresh.Controllers
{
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            return Ok(new { a = "selam" });
        }
    }
}
