using System.Collections.Generic;

namespace PizzaMVCApp.Models
{
    public class User
    {
        public User()
        {
            this.PizzaSuggestions = new HashSet<Pizza>();
        }
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Pizza> PizzaSuggestions { get; set; }
    }
}
