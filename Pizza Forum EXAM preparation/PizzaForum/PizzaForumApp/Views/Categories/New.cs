using System.Text;
using PizzaForumApp.Utillities;
using PizzaForumApp.ViewModels;
using SimpleMVC.Interfaces;

namespace PizzaForumApp.Views.Categories
{
    public class New : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(WebUtils.RetriveContentPathFolder(Constants.Header));

            string navLogged = WebUtils.RetriveContentPathFolder(Constants.NavLogged);
            htmlContent.AppendLine(string.Format(navLogged, ViewBag.Bag["username"]));

            htmlContent.AppendLine(WebUtils.RetriveContentPathFolder(Constants.AdminCategoryNew));
            htmlContent.AppendLine(WebUtils.RetriveContentPathFolder(Constants.Footer));
            return htmlContent.ToString();
        }
    }
}