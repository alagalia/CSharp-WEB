using PizzaMVCApp.Models;

namespace PizzaMVCApp.Data
{
    using System.Data.Entity;

    public class PizzaContext : DbContext
    {
        public PizzaContext()
            : base("name=PizzaContext")
        {
        }

       public virtual DbSet<User> Users { get; set; }
       public virtual DbSet<Pizza> Pizzas { get; set; }
       public virtual DbSet<Session> Sessions { get; set; }
    }
}