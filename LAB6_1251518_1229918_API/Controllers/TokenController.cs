using Microsoft.AspNetCore.Mvc;

namespace LAB6_1251518_1229918_API.Controllers
{
    [ApiController]
    public class TokenController : ControllerBase
    {

        [HttpPost]
        [Route("api/Token/Post/{key}")]
        public IActionResult SetToken([FromBody]Pizza json, string key)
        {
            var stringJson = "Id: " + json.Id.ToString() + ", Name: " + json.Id.ToString() + ", Size: " + json.Size.ToString();
            return RedirectToAction("GetToken", new { key = key, json = stringJson });
        }

        [HttpGet]
        [Route("api/Token/Get/{key}")]
        public ActionResult GetToken(string key, string json)
        {
            var token = tokenGen.tokenGenerator.generator(key, json);
            return Ok(token);
        }
    } 
}