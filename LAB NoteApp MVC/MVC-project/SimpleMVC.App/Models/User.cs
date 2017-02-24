using System.Collections;
using System.Collections.Generic;

namespace SimpleMVC.App.Models
{
    public class User
    {
        public User()
        {
            this.Notes = new HashSet<Note>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}