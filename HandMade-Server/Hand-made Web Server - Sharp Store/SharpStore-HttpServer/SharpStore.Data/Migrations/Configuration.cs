using SharpStore.Data.Models;

namespace SharpStore.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpStore.Data.SharpStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //protected override void Seed(SharpStore.Data.SharpStoreContext context)
        //{
        //    context.Knives.AddOrUpdate(
        //      k => k.Name,
        //      new Knife() {
        //          Name = "Knife1",
        //          ImageUrl = "",
        //          Price = 150
        //      },
        //      new Knife() {
        //          Name = "Knife2",
        //          ImageUrl = "",
        //          Price = 10
        //      },
        //      new Knife() {
        //          Name = "Knife3",
        //          ImageUrl = "",
        //          Price = 40
        //      },
        //          new Knife() {
        //              Name = "Sword",
        //              ImageUrl = "",
        //              Price = 40
        //          }
        //    );
        //}
    }
}
