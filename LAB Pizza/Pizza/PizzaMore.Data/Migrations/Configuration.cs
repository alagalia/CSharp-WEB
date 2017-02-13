namespace PizzaMore.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PizzaMore.Data.PmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PizzaMore.Data.PmContext";
        }

        protected override void Seed(PizzaMore.Data.PmContext context)
        {
            
        }
    }
}
