using System.Data.Entity;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Interfaces.Security;

namespace SimpleMVC.App.Data
{
    public class NoteAppContext : DbContext, IDbIdentityContext
    {
        
        public NoteAppContext()
            : base("name=NoteAppContext")
        {
           
        }

        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Note> Notes { get; set; }

        void IDbIdentityContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}