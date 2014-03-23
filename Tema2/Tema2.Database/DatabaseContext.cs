using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tema2.Database.Entitati;

namespace Tema2.Database
{
    public class DatabaseContext: DbContext 
    {
        public DatabaseContext()
            : base("Tema2ConnectionString") 
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
        
}