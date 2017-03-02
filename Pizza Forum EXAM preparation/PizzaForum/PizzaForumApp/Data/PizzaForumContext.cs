using PizzaForumApp.Models;

namespace PizzaForumApp.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PizzaForumContext : DbContext
    {
       
        public PizzaForumContext()
            : base("name=PizzaForumContext")
        {
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Category> Categories{ get; set; }
        public virtual DbSet<Topic> Topics{ get; set; }
        public virtual DbSet<Reply> Replies{ get; set; }
    }
}