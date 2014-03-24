using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tema2.Database.Entitati
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public float Value { get; set; }
    }
}