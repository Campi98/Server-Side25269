using dWeb2024.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace dWeb2024.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "https://localhost:3000/", headers:"*", methods:"*")]
    public class UserApiController : ControllerBase
    {
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok("oi");
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult LoginUser()
        {
            return Ok("oi");
        }

    }


    //[HttpPost]
    //[Route("fileSubmit")]
    //public IActionResult FileSubmit([FromForm] FileSubmitModel fileSubmitModel)
    //{
    //    IFormFile formFileformFile = _autService.GetFile();

    //    if (formFile == null)
    //    {
    //        return BadRequest("File not found");
    //    }
    //    return Ok("File submitted");
    //}

}
