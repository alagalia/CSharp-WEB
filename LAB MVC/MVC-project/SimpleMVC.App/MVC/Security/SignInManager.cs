using System.Linq;
using SimpleHttpServer.Models;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.MVC.Security
{
    public class SignInManager
    {
        private IDbIdentityContext dbContext;

        public SignInManager(IDbIdentityContext context)
        {
            this.dbContext = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            var login = this.dbContext.Logins.SingleOrDefault(l => l.SessionId == session.Id && l.IsActive);
            if (login != null)
            {
                return true;
            }
            return false;
        }
    }
}