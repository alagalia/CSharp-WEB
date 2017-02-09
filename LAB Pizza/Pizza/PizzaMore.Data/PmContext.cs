using PizzaMore.Data.Models;

namespace PizzaMore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PmContext : DbContext
    {
        
        public PmContext()
            : base("name=PmContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
    }
}