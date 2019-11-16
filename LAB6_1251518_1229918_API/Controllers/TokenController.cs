using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LAB6_1251518_1229918_API.Controllers
{
    [ApiController]
    public class TokenController : ControllerBase
    {

        [HttpPost]
        [Route("api/Token/Post/{key}")]
        public IActionResult SetToken([FromBody]Dictionary<string, object> json, string key)
        {
            key = key.PadLeft(256, ' ');
            var stringJson = string.Join(",", json.Select(x => x.Key + ":" + x.Value).ToArray());
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