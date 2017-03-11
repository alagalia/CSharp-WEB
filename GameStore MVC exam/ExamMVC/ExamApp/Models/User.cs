using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamApp.Models
{
    public class User
    {
        public User()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+@([a-zA-Z0-9-]+)+\.[a-zA-Z]+$")]
        public string Email { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}