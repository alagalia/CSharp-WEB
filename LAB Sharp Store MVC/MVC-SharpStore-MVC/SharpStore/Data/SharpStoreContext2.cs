using SharpStore.Models;

namespace SharpStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SharpStoreContext2 : DbContext
    {
        public SharpStoreContext2()
            : base("name=SharpStoreContext2")
        {
        }

        public virtual DbSet<Knife> Knives { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Purchase> Purchases{ get; set; }
    }
}