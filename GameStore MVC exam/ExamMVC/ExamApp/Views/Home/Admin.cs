using System.Text;
using ExamApp.Utilities;
using ExamApp.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace ExamApp.Views.Home
{
    public class Admin :IRenderable<AllAdminGamesViewModel>
    {
        public AllAdminGamesViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder allgamesBuilder = new StringBuilder();
            string header = WebUtils.RetriveContentPathFolder(Constants.Header);
            string navLogged = WebUtils.RetriveContentPathFolder(Constants.NavLogged);
            string container = WebUtils.RetriveContentPathFolder(Constants.AdminGames);
            string games = Model.ToString();
            container = string.Format(container, games);
            string footer = WebUtils.RetriveContentPathFolder(Constants.Footer);

            allgamesBuilder.AppendLine(header);
            allgamesBuilder.AppendLine(navLogged);
            allgamesBuilder.AppendLine(container);
            allgamesBuilder.AppendLine(footer);
            return allgamesBuilder.ToString();
        }

    }
}