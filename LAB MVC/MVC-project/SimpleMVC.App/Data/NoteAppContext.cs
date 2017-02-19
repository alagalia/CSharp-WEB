using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NoteAppContext : DbContext, IDbIdentityContext
    {
        
        public NoteAppContext()
            : base("name=NoteAppContext")
        {
        }

        public virtual DbSet<Login> Logins { get; }
        public virtual DbSet<User> Users { get; set; }
        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public virtual DbSet<Note> Notes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}