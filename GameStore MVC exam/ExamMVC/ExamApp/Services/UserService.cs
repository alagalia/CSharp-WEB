using System.Linq;
using ExamApp.BindingModels;
using ExamApp.Models;

namespace ExamApp.Services
{
    public class UserService : Service
    {
        public void RegisterUser(RegisterBindingModel model)
        {
            User user = new User()
            {

                Email = model.RegisterEmail,
                FullName = model.RegisterFullName,
                Password = model.RegisterPassword,
                IsAdmin = !Context.Users.Any(),
            };
            Context.Users.Add(user);
            Context.SaveChanges();

        }
        #region Add ERROR for REGISTRATIOn

        //public HashSet<RegistrationVerificationErrorViewModel> ValidateUserRegister(RegisterBindingModel urbm)
        //{
        //    HashSet<RegistrationVerificationErrorViewModel> revms = new HashSet<RegistrationVerificationErrorViewModel>();
        //    if (urbm.RegisterUserName.Length < 5 || urbm.RegisterUserName.Length > 30)
        //    {
        //        revms.Add(new RegistrationVerificationErrorViewModel(Constants.UserNameLengthErrorMessage));
        //    }

        //    Regex specialSymbolrgx = new Regex(@"[!@#$%^&*,.]");
        //    if (urbm.RegisterUserPassword.Length < 8 || !urbm.RegisterUserPassword.Any(char.IsUpper) || !urbm.RegisterUserPassword.Any(char.IsDigit) ||
        //        !specialSymbolrgx.IsMatch(urbm.RegisterUserPassword))
        //    {
        //        revms.Add(new RegistrationVerificationErrorViewModel(Constants.PasswordIncorrectFormatMessage));
        //    }
        //    if (urbm.RegisterUserPassword != urbm.RegisterUserConfirmPassword)
        //    {
        //        revms.Add(new RegistrationVerificationErrorViewModel(Constants.PasswordsDoNotMatchMessage));
        //    }
        //    return revms;

        //}
        #endregion

        public bool IsRegisterBidingModelValid(RegisterBindingModel model)
        {
            if (model.RegisterUserConfirmPassword != model.RegisterPassword)
            {
                return false;
            }
            if (Context.Users.Any(u => u.Email == model.RegisterEmail))
            {
                return false;
            }
            return true;
        }

        public bool IsLoginBidingModelValid(LoginBidingModel model)
        {
            return Context.Users.Any(
                u =>
                    (u.Email == model.LoginEmail  && u.Password == model.LoginPassword));
        }

        public User GetuserFromLoginBind(LoginBidingModel model)
        {
            return Context.Users.First(
                u =>
                    (u.Email == model.LoginEmail &&u.Password == model.LoginPassword));
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