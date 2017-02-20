﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleMVC.App.Models
{
    public class Login
    {
        public int Id { get; set; }

        public string SessionId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public bool IsActive { get; set; }
    }
}