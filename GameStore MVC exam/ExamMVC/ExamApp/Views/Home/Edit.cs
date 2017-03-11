using System.Text;
using ExamApp.Utilities;
using ExamApp.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace ExamApp.Views.Home
{
    public class Edit : IRenderable<GameDetailsViewModel>
    {
        public GameDetailsViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            string header = WebUtils.RetriveContentPathFolder(Constants.Header);
            string navLogged = WebUtils.RetriveContentPathFolder(Constants.NavLogged);
            string container = WebUtils.RetriveContentPathFolder(Constants.EditGames);
            container = string.Format(container, 
                Model.Id, 
                Model.Title, 
                Model.Description, 
                Model.ImageThumbnail, 
                Model.Price, 
                Model.Size, 
                Model.Trailer);
            string footer = WebUtils.RetriveContentPathFolder(Constants.Footer);

            sb.AppendLine(header);
            sb.AppendLine(navLogged);
            sb.AppendLine(container);
            sb.AppendLine(footer);
            return sb.ToString();
        }

    }
}