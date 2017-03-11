using System.Linq;
using ExamApp.Data;
using ExamApp.Models;
using ExamApp.Utilities;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;

namespace ExamApp.Security
{
    public class AuthenticationManager
    {
        private static SoftUniStoreContext context = Data.Data.Context;

        public static bool IsAuthenticated(string sessionId)
        {
            if (sessionId == null)
            {
                return false;
            }
            bool isAuthenticated = context.Sessions.Any(s => s.SessionId == sessionId && s.IsActive);
            return isAuthenticated;
        }

        public static User GetAuthenticateduser(string sessionId)
        {
            User userAuthenticated = context.Sessions.FirstOrDefault(s => s.SessionId == sessionId && s.IsActive)?.User;
            if (userAuthenticated != null)
            {
                ViewBag.Bag["username"] = userAuthenticated.Email;
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