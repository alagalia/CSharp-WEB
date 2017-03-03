using System.Linq;
using PizzaMVCApp.BindingModels;
using PizzaMVCApp.Data;
using PizzaMVCApp.Models;
using SimpleHttpServer.Models;

namespace PizzaMVCApp.Services
{
    public class UserService :Service
    {
        public UserService(PizzaContext context) : base(context)
        {
        }
        public void SignUpUser(SignUpBindinModel model)
        {
            User user = new User()
            {
                Email = model.SignUpEmail,
                Password = model.SignUpPassword
            };
            Context.Users.Add(user);
            Context.SaveChanges();
        }

        public User SignInUser(SignInBidingModel model, HttpSession session)
        {
            User user =
                Context.Users.FirstOrDefault(u => u.Password == model.SignInPassword && u.Email == model.SignInEmail);
            

            if (user != null)
            {
                Session sessionEntity = new Session()
                {
                    SessionId = session.Id,
                    IsActive = true,
                    UserId = user.Id
                };

                Context.Sessions.Add(sessionEntity);
                Context.SaveChanges();
            }
            return user;
        }

    }
}