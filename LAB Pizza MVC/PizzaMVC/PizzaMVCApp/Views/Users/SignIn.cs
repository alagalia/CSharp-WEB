using PizzaMVCApp.Utillities;
using SimpleMVC.Interfaces;

namespace PizzaMVCApp.Views.Users
{
    public class SignIn : IRenderable
    {
        public string Render()
        {
            return WebUtils.RetriveContentPathFolder(Constants.UserSignIn);
        }
    }
}