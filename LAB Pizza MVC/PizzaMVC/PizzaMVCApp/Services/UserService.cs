using System.Linq;
using PizzaMVCApp.BindingModels;
using PizzaMVCApp.Data;
using PizzaMVCApp.Models;

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

        public User SignInUser(SignInBidingModel model)
        {
            User user =
                Context.Users.FirstOrDefault(u => u.Password == model.SignInPassword && u.Email == model.SignInEmail);
            return user;
        }

    }
}