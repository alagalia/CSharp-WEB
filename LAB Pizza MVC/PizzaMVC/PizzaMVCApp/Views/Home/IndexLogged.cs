using PizzaMVCApp.Utillities;
using SimpleMVC.Interfaces;

namespace PizzaMVCApp.Views.Home
{
    public class IndexLogged : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtils.RetriveContentPathFolder(Constants.HomeIndexLogged);
            return htmlContent;
        }
    }
}