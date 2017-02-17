using SharpStore.Data.Models;

namespace SharpStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("name=SharpStoreContex")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Knife> Knives { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    }
    
}