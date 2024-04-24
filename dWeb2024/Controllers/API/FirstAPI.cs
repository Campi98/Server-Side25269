using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace dWeb2024.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "https://localhost:3000/", headers:"*", methods:"*")]
    public class FirstAPI : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok("oi");
        }
    }
}
