using PizzaMVCApp.Utillities;
using SimpleMVC.Interfaces;

namespace PizzaMVCApp.Views.Home
{
    class Index : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtils.RetriveContentPathFolder(Constants.HomeIndex);
            return htmlContent;
        }
    }
}
