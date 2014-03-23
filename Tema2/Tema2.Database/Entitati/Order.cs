using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tema2.Database.Entitati
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public float Value { get; set; }
    }
}