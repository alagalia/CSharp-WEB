using System.Data.Entity;
using ExamApp.Models;

namespace ExamApp.Data
{
    public class SoftUniStoreContext : DbContext
    {
        public SoftUniStoreContext()
            : base("name=SoftUniStoreContext")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
    }   
}