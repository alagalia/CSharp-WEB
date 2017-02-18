using SimpleMVC.App.Models;

namespace SimpleMVC.App.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NoteAppContext : DbContext
    {
        
        public NoteAppContext()
            : base("name=NoteAppContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}