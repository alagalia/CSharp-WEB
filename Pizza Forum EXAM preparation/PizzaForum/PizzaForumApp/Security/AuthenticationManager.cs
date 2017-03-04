using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using PizzaForumApp.Data;
using PizzaForumApp.Models;
using PizzaForumApp.Views.Forum;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;

namespace PizzaForumApp.Security
{
    public class AuthenticationManager
    {
        private static PizzaForumContext context = Data.Data.Context;

        public static bool IsAuthenticated(string sessionId)
        {
            bool isAuthenticated = context.Sessions.Any(s => s.SessionId == sessionId && s.IsActive);
            return isAuthenticated;
        }

        public static User GetAuthenticateduser(string sessionId)
        {
            User userAuthenticated = context.Sessions.FirstOrDefault(s => s.SessionId == sessionId && s.IsActive)?.User;
            if (userAuthenticated != null)
            {
                ViewBag.Bag["username"]= userAuthenticated.Username;
            }
            return userAuthenticated;

        }

        public static void Logout(HttpResponse response, string sessionId)
        {
            ViewBag.Bag["username"] = null;
            Session currentSession = context.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
            if (currentSession != null) currentSession.IsActive = false;
            context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}