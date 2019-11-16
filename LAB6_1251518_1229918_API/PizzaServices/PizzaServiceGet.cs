using LAB6_1251518_1229918_API.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB6_1251518_1229918_API.PizzaServices
{
    public class PizzaServiceGet
    {
        private readonly IMongoCollection<PizzaIngridients> _pizza;
        public PizzaServiceGet(IPizzaDatabase settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _pizza = database.GetCollection<PizzaIngridients>(settings.PizzaCollectionName);
        }
        public List<PizzaIngridients> GetAll()
        {
            return _pizza.Find(x => true).ToList();
        }
        public PizzaIngridients Get(string id) =>
            _pizza.Find<PizzaIngridients>(p => p.Id == id).FirstOrDefault();

        public PizzaIngridients Insertar(PizzaIngridients pizza)
        {
            _pizza.InsertOneAsync(pizza);
            return pizza;
        }
        public async void Eliminar(PizzaIngridients pizza)
        {
            //Hay que esperar por lo que dijo el ingeniero Godoy de que puede avanzar, pero no obtiene todos lo valores
            await _pizza.DeleteOneAsync((x => x.Id == pizza.Id));
        }
        public async void Modificar(string id, PizzaIngridients pizza)
        {
            //Hay que esperar por lo que dijo el ingeniero Godoy de que puede avanzar, pero no obtiene todos lo valores
            await _pizza.ReplaceOneAsync(pizzza => pizzza.Id == id, pizza);
        }
    }
}
