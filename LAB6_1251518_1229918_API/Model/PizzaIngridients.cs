using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB6_1251518_1229918_API.Model
{
    public class PizzaIngridients
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Nombre")]
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Ingredientes { get; set; }
        public string MassType { get; set; }
        public string Tamaño { get; set; }
        public int CantidadPorciones { get; set; }
        public bool ExtraCheese { get; set; }
    }
}
