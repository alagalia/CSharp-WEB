﻿using System;

namespace PizzaForumApp.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }
        public DateTime? PublishDate { get; set; }
        public string ImageUrl { get; set; }
        public virtual Topic Topic { get; set; }

    }
}