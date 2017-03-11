using System.Text;
using ExamApp.Utilities;
using SimpleMVC.Interfaces;

namespace ExamApp.Views.Home
{
    public class Add :IRenderable
    {
        public string Render()
        {
            StringBuilder allgamesBuilder = new StringBuilder();
            string header = WebUtils.RetriveContentPathFolder(Constants.Header);
            string navLogged = WebUtils.RetriveContentPathFolder(Constants.NavLogged);
            string container = WebUtils.RetriveContentPathFolder(Constants.Addgame);
            string footer = WebUtils.RetriveContentPathFolder(Constants.Footer);

            allgamesBuilder.AppendLine(header);
            allgamesBuilder.AppendLine(navLogged);
            allgamesBuilder.AppendLine(container);
            allgamesBuilder.AppendLine(footer);
            return allgamesBuilder.ToString();
        }
    }
}