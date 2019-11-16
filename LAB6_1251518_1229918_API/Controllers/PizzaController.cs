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
    public class PizzaController : ControllerBase
    {
        private readonly PizzaServiceGet pizza;
        public PizzaController(PizzaServiceGet service)
        {
            pizza = service;
        }
        // GET: api/Pizza
        [HttpGet]
        public IEnumerable<PizzaIngridients> Get()
        {
            return pizza.GetAll();
        }
        // GET: api/Pizza/5
        [HttpGet("{Id}", Name = "Get")]
        public IActionResult Get(string Id)
        {
            var pitza = pizza.Get(Id);
            if (pitza == null)
            {
                return NotFound();
            }
            return Ok(pitza);
        }
        // POST: api/Pizza
        [HttpPost]
        public void Post(PizzaIngridients pizzas)
        {
            pizza.Insertar(pizzas);
        }
        // PUT: api/Pizza/5
        [HttpPut]
        public IActionResult Put(PizzaIngridients pizzas)
        {
            var pitza = pizza.Get(pizzas.Id);

            if (pitza == null)
            {
                return NotFound();
            }
            pizza.Modificar(pizzas.Id, pizzas);
            return NoContent();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete(PizzaIngridients pizzas)
        {
            var pitza = pizza.Get(pizzas.Id);

            if (pitza == null)
            {
                return NotFound();
            }
            pizza.Eliminar(pizzas);
            return NoContent();
        }
    }
}
