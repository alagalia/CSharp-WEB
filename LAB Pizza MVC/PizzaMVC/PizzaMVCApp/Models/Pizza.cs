using System.ComponentModel.DataAnnotations;

namespace PizzaMVCApp.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required, MaxLength(100)]
        public string Recipe { get; set; }

        public string ImageUrl { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public virtual User Owner { get; set; }

    }
}