using Microsoft.AspNetCore.Mvc;
using Dealership.Models;
using Microsoft.AspNetCore.Http.Extensions;

namespace Dealership.Controllers
{
    [ApiController]
    [Route("api")]
    public class DealershipController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;

        public DealershipController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetApi()
        {
            var url = HttpContext.Request.GetEncodedUrl();
            var links = new List<Link>
            {
               new Link(url + "/cars",
                "get_cars",
                "GET"),
               new Link(url + "/transactions",
               "get_transactions",
               "GET")
                
            };

            return Ok(links);
        }

    }
}
