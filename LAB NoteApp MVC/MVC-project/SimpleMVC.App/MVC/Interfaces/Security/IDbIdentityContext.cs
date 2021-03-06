﻿using System.Data.Entity;
using SimpleMVC.App.Models;

namespace SimpleMVC.App.MVC.Interfaces.Security
{
    public interface IDbIdentityContext
    {
        DbSet<Login> Logins { get; }
        DbSet<User> Users { get; }
        void SaveChanges();
    }
}