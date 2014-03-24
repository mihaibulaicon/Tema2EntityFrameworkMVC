using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tema2.Database.Entitati
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }

        [Key, ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }
        public float Value { get; set; }
        public int Serial { get; set; }
    }
}