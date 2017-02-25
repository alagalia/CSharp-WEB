using PizzaMVCApp.Models;

namespace PizzaMVCApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PizzaMVCApp.Data.PizzaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PizzaMVCApp.Data.PizzaContext context)
        {
            context.Pizzas.AddOrUpdate(
              p => p.Title,
              new Pizza { Title = "Andrew Peters", DownVotes = 0, UpVotes = 0, ImageUrl = "http://www.pngall.com/wp-content/uploads/2016/05/Pizza-Free-PNG-Image.png", Recipe = "Test TestTestTestTest TestTestTest" }
            );
        }
    }
}
