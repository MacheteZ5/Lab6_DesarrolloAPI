using Microsoft.AspNetCore.Mvc;
namespace LAB6_1251518_1229918_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public ActionResult SetToken(string key)
        {
            return RedirectToAction("GetToken", new { key = key });
        }
        [HttpGet]
        public ActionResult GetToken(string key)
        {
            var token = tokenGen.tokenGenerator.generator(key);
            return Ok(token);
        }
    }
}