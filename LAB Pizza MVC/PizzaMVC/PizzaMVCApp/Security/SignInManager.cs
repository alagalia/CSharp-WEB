using System;
using System.Linq;
using PizzaMVCApp.Data;
using PizzaMVCApp.Models;
using SimpleHttpServer.Models;

namespace PizzaMVCApp.Security
{
    public class SignInManager
    {
        public PizzaContext dbContext;

        public SignInManager(PizzaContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            bool isAuthenticated = dbContext.Sessions.Any(s => s.SessionId == session.Id && s.IsActive);
            return isAuthenticated;
        }


        public void LogOut(HttpSession session)
        {
            Session sessionEntity = dbContext.Sessions.FirstOrDefault(s => s.SessionId == session.Id);
            if (sessionEntity != null)
            {
                sessionEntity.IsActive = false;
                session.Id = new Random().Next().ToString();//TODO set to cookies!
                this.dbContext.SaveChanges();
            }
        }
    }
}