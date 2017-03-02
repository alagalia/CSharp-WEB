using System.Text;
using PizzaForumApp.Utillities;
using SimpleMVC.Interfaces;

namespace PizzaForumApp.Views.Forum
{
    class Register : IRenderable
    {
        public string Render()
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.AppendLine(WebUtils.RetriveContentPathFolder(Constants.Header));
            htmlContent.AppendLine(WebUtils.RetriveContentPathFolder(Constants.NavNotLogged));
            htmlContent.AppendLine(WebUtils.RetriveContentPathFolder(Constants.Register));
            htmlContent.AppendLine(WebUtils.RetriveContentPathFolder(Constants.Footer));
            return htmlContent.ToString();
        }
    }
}
