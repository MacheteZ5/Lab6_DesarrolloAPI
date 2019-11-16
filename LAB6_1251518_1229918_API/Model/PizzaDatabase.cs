using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB6_1251518_1229918_API.Model
{
    public class PizzaDatabase : IPizzaDatabase
    {
        public string PizzaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IPizzaDatabase
    {
        string PizzaCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
