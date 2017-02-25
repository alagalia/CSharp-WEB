using PizzaMVCApp.Utillities;
using SimpleMVC.Interfaces;

namespace PizzaMVCApp.Views.Users
{
    public class SignUp : IRenderable
    {
        public string Render()
        {
            return WebUtils.RetriveContentPathFolder(Constants.UserSignUp);
        }
    }
   
}