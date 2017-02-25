using PizzaMVCApp.Data;
using PizzaMVCApp.Models;
using SimpleHttpServer.Models;

namespace PizzaMVCApp.Services
{
    public class SessionService : Service
    {
        public SessionService(PizzaContext context) : base(context)
        {
        }

        public void AddUserSession(User user, HttpSession session)
        {
            Session sessionEntity = new Session()
            {
                SessionId = session.Id,
                IsActive = true,
                User = user
            };
            Context.Sessions.Add(sessionEntity);
            Context.SaveChanges();
        }
    }
}