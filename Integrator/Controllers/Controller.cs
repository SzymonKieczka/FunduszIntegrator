using Microsoft.AspNetCore.Mvc;

namespace Integrator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private readonly ILogger<Controller> _logger;

        public Controller(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet("hello")]
        public string Get()
        {
            return "hello world";
        }
    }
}
