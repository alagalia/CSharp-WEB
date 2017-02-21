using System.Text;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;

namespace SimpleMVC.App.Views.Users
{
    public class Greet : IRenderable<GreetViewModel>
    {
        public GreetViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("</h3>Hello user with session id: " + this.Model.SessionId);
            sb.AppendLine("<form action=\"logout\" method=\"post\"><br/>");
            sb.AppendLine("<input type=\"submit\" value=\"logout\">");
            sb.AppendLine("</form><br/>");
            return sb.ToString();
        }

    }
}