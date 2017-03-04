using System.Collections.Generic;

namespace PizzaForumApp.Models
{
    public class User
    {
        public User()
        {
            this.Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public bool IsAdimn { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}