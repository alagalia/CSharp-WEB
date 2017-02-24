using SharpStore.Models;

namespace SharpStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpStore.Data.SharpStoreContext2>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.SharpStoreContext2 context)
        {

            context.Knives.AddOrUpdate(knive => knive.Name, new Knife[]
            {
                new Knife()
                {
                    Name = "Knife1",
                    Price = 130,
                    ImageUrl = "https://tctechcrunch2011.files.wordpress.com/2015/11/panda.jpg?w=738"
                },
                new Knife()
                {
                    Name = "Knife2",
                    Price = 130,
                    ImageUrl = "http://comps.canstockphoto.com/can-stock-photo_csp7851758.jpg"
                }
                ,
                new Knife()
                {
                    Name = "Sword",
                    Price = 200,
                    ImageUrl = "https://ae01.alicdn.com/kf/HTB1diTfLVXXXXbkXFXXq6xXFXXXR/tree-MAN-font-b-face-b-font-spine-psychedelic-Trippy-font-b-art-b-font-poster.jpg"
                }
            });
        }
    }
}
