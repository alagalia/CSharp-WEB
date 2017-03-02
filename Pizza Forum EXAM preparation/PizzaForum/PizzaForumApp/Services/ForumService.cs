using System.Linq;
using System.Text.RegularExpressions;
using PizzaForumApp.BindingModels;
using PizzaForumApp.Controllers;
using PizzaForumApp.Data;
using PizzaForumApp.Models;

namespace PizzaForumApp.Services
{
    public class ForumService : Service
    {
        public void RegisterUser(RegisterBindingModel model)
        {
            User user = new User()
            {
                Username = model.RegisterUserName,
                Email = model.RegisterUserEmail,
                Password = model.RegisterUserPassword,
                IsAdimn = !Context.Users.Any(),
            };
            Context.Users.Add(user);
            Context.SaveChanges();

        }

        public bool IsRegisterBidingModelValid(RegisterBindingModel model)
        {
            if (model.RegisterUserConfirmPassword != model.RegisterUserPassword)
            {
                return false;
            }
            if (model.RegisterUserName.Length < 3)
            {
                return false;
            }
            Regex regUserName = new Regex("[a-z0-9]+$");
            if (!regUserName.IsMatch(model.RegisterUserName))
            {
                return false;
            }
            if (!model.RegisterUserEmail.Contains("@"))
            {
                return false;
            }

            Regex regPassword = new Regex("^[0-9]{4}$");
            if (!regPassword.IsMatch(model.RegisterUserPassword))
            {
                return false;
            }

            if (Context.Users.Any(u => u.Email == model.RegisterUserEmail || u.Email == model.RegisterUserEmail))
            {
                return false;
            }
            return true;
        }

        public bool IsLoginBidingModelValid(LoginBidingModel model)
        {
            return Context.Users.Any(
                u =>
                    (u.Email == model.LoginCredential || u.Username == model.LoginCredential) &&
                    u.Password == model.LoginPassword);
        }

        public User GetuserFromLoginBind(LoginBidingModel model)
        {
            return Context.Users.First(
                u =>
                    (u.Email == model.LoginCredential || u.Username == model.LoginCredential) &&
                    u.Password == model.LoginPassword);
        }

        public void LogInUser(User user, string sessionId)
        {
            this.Context.Sessions.Add(new Session()
            {
                User = user,
                SessionId = sessionId,
                IsActive = true
            });
            this.Context.SaveChanges();
        }
    }
}