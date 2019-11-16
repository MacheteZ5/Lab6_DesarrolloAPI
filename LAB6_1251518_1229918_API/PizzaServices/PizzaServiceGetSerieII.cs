using LAB6_1251518_1229918_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB6_1251518_1229918_API.PizzaServices
{
    public class PizzaServiceGetSerieII
    {
        public List<PizzaIngridients> GetAll(List<PizzaIngridients> _pizza)
        {
            return _pizza;
        }
        public PizzaIngridients Get(List<PizzaIngridients> _pizza, string Id)
        {
            var selection = new PizzaIngridients();
            foreach (var ingredientes in _pizza)
            {
                if (ingredientes.Id == Id)
                {
                    selection = ingredientes;
                }
            }
            return selection;
        }
        public List<PizzaIngridients> Modificar(List<PizzaIngridients> _pizza, PizzaIngridients pizza)
        {
            foreach (var ingredientes in _pizza)
            {
                if (ingredientes.Id == pizza.Id)
                {
                    _pizza.Remove(ingredientes);
                    break;
                }
            }
            _pizza.Add(pizza);
            return _pizza;
        }
        public List<PizzaIngridients> Eliminar(List<PizzaIngridients> _pizza, PizzaIngridients pizza)
        {
            foreach (var ingredientes in _pizza)
            {
                if (ingredientes.Id == pizza.Id)
                {
                    _pizza.Remove(ingredientes);
                    break;
                }
            }
            return _pizza;
        }
    }
}
