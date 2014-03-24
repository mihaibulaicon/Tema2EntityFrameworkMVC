using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tema2.Database.Entitati;
using System.Web.Mvc;
namespace Tema2.Models
{
    public class OrderModel
    {
        public Order Order { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
    }
}