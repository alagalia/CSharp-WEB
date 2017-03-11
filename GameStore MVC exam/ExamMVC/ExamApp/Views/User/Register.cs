using System.Text;
using ExamApp.Utilities;
using SimpleMVC.Interfaces;

namespace ExamApp.Views.User
{
    public class Register :IRenderable
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