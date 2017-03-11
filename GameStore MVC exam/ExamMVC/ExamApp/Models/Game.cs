using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamApp.Models
{
    public class Game
    {
        public Game()
        {
            this.Users = new HashSet<User>();
        }
        public int Id { get; set; }

        [MinLength(3), MaxLength(100)]
        public string Title { get; set; }

        [StringLength(11)]
        public string Trailer { get; set; }

        [RegularExpression(@"http:\/{2}|https:\/{2}")]
        public string ImageThumbnail { get; set; }

        [MinLength(1)]
        public double Size { get; set; }

        [MinLength(1)]
        public double Price { get; set; }

        [MinLength(20)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}