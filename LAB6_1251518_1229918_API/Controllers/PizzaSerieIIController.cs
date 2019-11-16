using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB6_1251518_1229918_API.Model;
using LAB6_1251518_1229918_API.PizzaServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LAB6_1251518_1229918_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaSerieIIController : ControllerBase
    {
        static PizzaServiceGetSerieII Pizza = new PizzaServiceGetSerieII();
        static List<PizzaIngridients> pizza = new List<PizzaIngridients>();
        // GET: api/PizzaSerieII
        [HttpGet]
        public IActionResult Get()
        {
            var pitza = Pizza.GetAll(pizza);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pitza);
        }
        // GET: api/PizzaSerieII/5
        [HttpGet(("{Id}"))]
        public IActionResult Get(string id)
        {
            var pitza = Pizza.Get(pizza, id);
            if (pitza == null)
            {
                return NotFound();
            }
            return Ok(pitza);
        }

        // POST: api/PizzaSerieII
        [HttpPost]
        public void Post(PizzaIngridients pizzas)
        {
            pizza.Add(pizzas);
        }

        // PUT: api/PizzaSerieII/5
        [HttpPut]
        public IActionResult Put(PizzaIngridients pizzas)
        {
            var pitza = Pizza.Get(pizza, pizzas.Id);
            if (pitza == null)
            {
                return NotFound();
            }
            pizza = Pizza.Modificar(pizza, pizzas);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete(PizzaIngridients pizzas)
        {
            var pitza = Pizza.Get(pizza, pizzas.Id);
            if (pitza == null)
            {
                return NotFound();
            }
            pizza = Pizza.Eliminar(pizza, pizzas);
            return NoContent();
        }
    }
}
