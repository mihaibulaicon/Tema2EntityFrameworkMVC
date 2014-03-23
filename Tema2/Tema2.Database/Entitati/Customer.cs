using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tema2.Database.Entitati
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Address { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}