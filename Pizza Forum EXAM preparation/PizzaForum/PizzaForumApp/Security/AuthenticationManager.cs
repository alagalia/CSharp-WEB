using System;
using System.Linq;
using PizzaForumApp.Data;
using PizzaForumApp.Models;
using SimpleHttpServer.Models;

namespace PizzaForumApp.Security
{
    public class AuthenticationManager
    {
        private static PizzaForumContext dbContext = Data.Data.Context;

        public static bool IsAuthenticated(string sessionId)
        {
            bool isAuthenticated = dbContext.Sessions.Any(s => s.SessionId == sessionId && s.IsActive);
            return isAuthenticated;
        }

        public static User GetAuthenticateduser(string sessionId)
        {
            User userAuthenticated = dbContext.Sessions.FirstOrDefault(s => s.SessionId == sessionId && s.IsActive).User;
            ViewBag.Bag["username"]= userAuthenticated.Username;
            return userAuthenticated;
        }



        public void Logout(HttpSession httpSession)
        {
            using (dbContext)
            {
                Session session = dbContext
                    .Sessions
                    .FirstOrDefault(s => s.SessionId == httpSession.Id);

                if (session != null)
                {
                    session.IsActive = false;
                    httpSession.Id = new Random().Next().ToString();
                    dbContext.SaveChanges();
                }
            }
        }
    }
}