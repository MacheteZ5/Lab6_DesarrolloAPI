using Microsoft.AspNetCore.Mvc;

namespace LAB6_1251518_1229918_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult SetToken([FromBody]string json, string key)
        {
            
            return RedirectToAction("GetToken", new { key = key,  json = json});
        }
        [HttpGet]
        public ActionResult GetToken(string key, string json)
        {
            var token = tokenGen.tokenGenerator.generator(key, json);
            return Ok(token);
        }
    }
}