
using Microsoft.AspNetCore.Mvc;

namespace weerp.Services.Products.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("WeErp Products Service");
    }
}
