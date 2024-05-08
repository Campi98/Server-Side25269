using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dWeb2024.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstAPI : ControllerBase
    {

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok("Ceninhas123");

        }


    }
}
