using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure;
namespace ApplicationAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Get()
        {
            var singleton = Singleton.Instance;
            return Ok(singleton);
        }
    }
}
